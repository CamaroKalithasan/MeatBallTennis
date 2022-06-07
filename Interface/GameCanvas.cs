using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Threading;
using System.IO;

namespace MeatballTennis
{
    public partial class GameCanvas : Form
    {
        private Image PaddleImage;
        private Image BallImage;

        private string ServerIPAddress;
        private string Port;

        private bool IsServer;
        private byte Player;
        
        static bool KeysUp = false;
        static bool KeysDown = false;
        static bool KeysQuit = false;

        private Client.GameState State;
        private Thread ClientThread;

        // Return Values
        public const byte SUCCESS = 0, SHUTDOWN = 1, DISCONNECT = 2,
                          BIND_ERROR = 3, CONNECT_ERROR = 4, SETUP_ERROR = 5,
                          STARTUP_ERROR = 6, ADDRESS_ERROR = 7, PARAMETER_ERROR = 8, MESSAGE_ERROR = 9;

        // Game Phases
        public const byte DISCONNECTED = 0, WAITING = 1, RUNNING = 2, GAMEOVER = 3;

        public GameCanvas()
        {
            InitializeComponent();
            State.BallX = 200;
            State.BallY = 200;
            State.GamePhase = WAITING;
            State.Player0.Y =
            State.Player1.Y = 128;
            State.Player0.Score = 0;
            State.Player1.Score = 0;
            State.Player0.KeyUp = false;
            State.Player0.KeyDown = false;
            State.Player1.KeyUp = false;
            State.Player1.KeyDown = false;
			GameTimer.Enabled = false;
        }

        /// <summary>
        /// The Heartbeat for the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (IsServer) serverTick();
            clientTick();
            this.Invalidate();
        }

        // Update the server.
        private void serverTick()
        {
            if (Server.update() == DISCONNECT)
            {
                State.GamePhase = DISCONNECTED;
                Server.stop();
                Client.stop();
            }
        }

        private void clientTick()
        {
            // Get the client's state.
            Client.getState(ref State);

            // If the client has been disconnected, deal with it.
            if (State.GamePhase == DISCONNECTED)
            {				
                if(IsServer) Server.stop();
				this.Close();
            }
        }

        /// <summary>
        /// The "Init" for the main game form (window).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameCanvas_Load(object sender, EventArgs e)
        {
			using (FileStream paddleStream = new FileStream("Assets/Paddle.png", FileMode.Open))
			{
				PaddleImage = Image.FromStream(paddleStream, true);
			}
			using (FileStream ballStream = new FileStream("Assets/Ball.png", FileMode.Open))
			{
				BallImage = Image.FromStream(ballStream, true);
			}

            GameSetup Setup = new GameSetup();
            Setup.ShowDialog();
            if (Setup.DialogResult == DialogResult.OK)
            {
                this.IsServer = Setup.IsServer;
                this.ServerIPAddress = Setup.IPaddress;
                this.Port = Setup.port;
                
                if (IsServer == true)
                {
                    ServerIPAddress = "127.0.0.1";
                    if (Server.init(ushort.Parse(Port)) != SUCCESS)
                    {
                        State.GamePhase = DISCONNECTED;
                        GameTimer.Enabled = true;
                        return;
                    }
                }
                if (IsServer)
				{
                    Player = 0;
					Server.update();
				}
                else
                    Player = 1;

				GameTimer.Enabled = true;
                ClientThread = new Thread(runClient);
                ClientThread.Start();
			}
            else
                this.Close();
        }

        /// <summary>
        /// Draws the images and score for the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameCanvas_Paint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.DrawImage(PaddleImage, 8, State.Player0.Y);
            e.Graphics.DrawImage(PaddleImage, 640 - (PaddleImage.Width + 8), State.Player1.Y);
            e.Graphics.DrawImage(BallImage, State.BallX, State.BallY);
            P1Score.Text = "P1: " + State.Player0.Score;
            P2Score.Text = "P2: " + State.Player1.Score;
            if (State.GamePhase == GAMEOVER)
                Gover.Visible = true;
            else
                Gover.Visible = false;

        }

        // Check downed key against old input; if changed, send a message.
        private void GameCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            // Set the key input values if a key has been pressed.
            if (Keys.Up == e.KeyCode)
                KeysUp = true;
            else if (Keys.Down == e.KeyCode)
                KeysDown = true;
            else if (Keys.Escape == e.KeyCode)
                KeysQuit = true;
            else
                return;

            // Get this player's current input.
            Client.Player myPlayer;

            if (Player == 0)
                myPlayer = State.Player0;
            else
                myPlayer = State.Player1;

            // Check the input against this player's input.
            if (KeysUp && !myPlayer.KeyUp || KeysDown && !myPlayer.KeyDown || KeysQuit)
            {
                int result = Client.sendInput(KeysUp, KeysDown, KeysQuit);

                if (result != SUCCESS)
                {
                    State.GamePhase = DISCONNECTED;
                    Client.stop();
                }
            }
        }

        // Check released key against old input; if changed, send a message.
        private void GameCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            // Ignore input if we're disconnected.
            if (State.GamePhase == DISCONNECTED)
                return;

            // Set the key input values if a key has been released.
            if (Keys.Up == e.KeyCode)
                KeysUp = false;
            else if (Keys.Down == e.KeyCode)
                KeysDown = false;
            else if (Keys.Escape == e.KeyCode)
                KeysQuit = false;
            else
                return;

            // Get this player's current input.
            Client.Player myPlayer;

            if (Player == 0)
                myPlayer = State.Player0;
            else
                myPlayer = State.Player1;

            // Check the input against this player's input.
            if (!KeysUp && myPlayer.KeyUp || !KeysDown && myPlayer.KeyDown)
            {
                int result = Client.sendInput(KeysUp, KeysDown, KeysQuit);

                if (result != SUCCESS)
                {
                    State.GamePhase = DISCONNECTED;
                    Client.stop();
                }
            }
        }

        private void runClient()
        {
			int result;

            result = Client.init(ServerIPAddress, ushort.Parse(Port), Player);

            if (result == SUCCESS)
			{
                // Run the client. If the client is not shutdown,
                // then stop the client by terminating all threads.
                result = Client.run();

                if (result != SHUTDOWN)
				{
                    Client.stop();
				}
            }
            else
            {
                Client.stop();
            }

            State.GamePhase = DISCONNECTED;
        }

        private void GameCanvas_FormClose(object sender, FormClosingEventArgs e)
        {
            Client.stop();
            Server.stop();

            if (ClientThread != null)
                ClientThread.Join();
        }
    }
}
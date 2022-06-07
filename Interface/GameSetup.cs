using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MeatballTennis
{
    public partial class GameSetup : Form
    {
        public GameSetup()
        {
            InitializeComponent();
            IsServer = true;

            OK.DialogResult = DialogResult.OK;
            Cancel.DialogResult = DialogResult.Cancel;
        }
        public bool IsServer;
        public string IPaddress;
        public string port;
      

        private void ServerButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ServerButton.Checked == true)
            {
                IsServer = true;
                IPAddress.Enabled = false;
            }
            else
            {
                IsServer = false;
                IPAddress.Enabled = true;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {

            IPaddress = IPAddress.Text;
            port = Port.Text;
            
        }

    }
}
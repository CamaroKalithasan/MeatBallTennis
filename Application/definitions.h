#include "platform.h"

#ifndef _DEFINITIONS_H_
#define _DEFINITIONS_H_

// Game Phases
const byte DISCONNECTED = 0, WAITING = 1, RUNNING = 2, GAMEOVER = 3;

// Message Types
const byte CL_CONNECT = 1, CL_KEYS = 2, CL_ALIVE = 3,
              SV_OKAY = 4, SV_FULL = 5, SV_SNAPSHOT = 6, SV_CL_CLOSE = 7;

// Return Values
const byte SUCCESS = 0, SHUTDOWN = 1, DISCONNECT = 2,
              BIND_ERROR = 3, CONNECT_ERROR = 4, SETUP_ERROR = 5,
              STARTUP_ERROR = 6, ADDRESS_ERROR = 7, PARAMETER_ERROR = 8, MESSAGE_ERROR = 9;

struct Player
{
	short y;
	short score;

	// NOTE: These are boolean variables, but bool is platform dependent.
	byte keyUp;
	byte keyDown;
};

struct GameState 
{
	byte gamePhase;

	short ballX;
	short ballY;

	Player player0;
	Player player1;
};

#define PADDLEX 64
#define PADDLEY 192
#define BALLX 64
#define BALLY 64
#define FIELDX 640
#define FIELDY 480

#define MAX_DATA 512
#endif

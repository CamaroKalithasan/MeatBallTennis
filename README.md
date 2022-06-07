# MeatBallTennis
Client Server Application for a Meatball Tennis game

Consists of C++ networking classes and a C# GUI frontend.


The server accepts connection requests from up to two clients. When a client connects to the server, it requests to either be the server-side client (on the listen server) or the standalone client. This dictates whether the client is Player 1 (left) or Player 2 (right). Clients send input messages to the server, and the server sends a snapshot every game tick. 


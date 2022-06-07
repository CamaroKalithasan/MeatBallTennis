// exceptions.h : Defines the exceptions for this program.

#ifndef _EXCEPTIONS_H_
#define _EXCEPTIONS_H_

#include <exception>

// Basic network exception class
class NetworkException : public std::exception
{
	public:
		NetworkException(const char* _description = "");
		const char* what();

	private:
		const char* description;
};

inline NetworkException::NetworkException(const char* _description) : description(_description)
{
}

inline const char* NetworkException::what()
{
	return description;	
}

// Derived exceptions
class NetStreamException : public NetworkException
{
	public:
		NetStreamException(const char* _description = "") {}
};

class NetMessageException : public NetworkException
{
	public:
		NetMessageException(const char* _description = "") {}
};

class NetAbnormalException : public NetworkException
{
	public:
		NetAbnormalException(const char* _description = "") {}
};

class NetGracefulException : public NetworkException
{
	public:
		NetGracefulException(const char* _description = "") {}
};

#endif

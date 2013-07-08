pong
====

A pong game, we have plans to use socket.io, node.js for server. 
no clue how we are gonna make client, still discussing that.
We are working on a client written in c# with XAML/wpf. We are using OpenGL with the SharpGL library, it wraps the OpenGL libraries wich are written for C/++.

The server is written in Javascript on Node.JS, and we are using the folowing libraries:
- Socket.io - 0.9.14              Included with project
- Express - 3.2.4                 Included with project

For the client we use the next libraries.
- http://sharpgl.codeplex.com - We are using version 2.1, this is an OpenGL Wrapper. We have included the library with the project.
- http://socketio4net.codeplex.com/ - We are using this library for comminucation with the server. The version wich we use is v0.6.26. We have inclued the library with the project.

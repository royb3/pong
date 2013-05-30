console.log("server starting");
var express = require('express'),
	app = express(),
	server = require('http').createServer(app),
	io = require('socket.io').listen(server);

server.listen(2525);
io.set('log level', 3);

io.sockets.on('connection', function(socket) {
	socket.on('send_broadcast', function(data){
		socket.broadcast.emit('send_broadcast', data);
	});
});

console.log("server running");
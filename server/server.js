console.log("server starting");
var express = require('express'),
	app = express(),
	server = require('http').createServer(app),
	io = require('socket.io').listen(server);

var playerlist = [];


server.listen(2525);
io.set('log level', 3);

io.sockets.on('connection', function(socket) {
	socket.on('send_broadcast', function(data){
		socket.broadcast.emit('send_broadcast', data);
	});


socket.on('initializeplayer', function (newplayername) {
	socket.clientname = newplayername;
	playerlist.push(newplayername);
	io.sockets.emit('addplayer', playerlist, newplayername);
	});


socket.on('disconnect', function(){
	//delete playerlist[socket.clientname];
	for(var i in playerlist)
	{
		delete playerlist[socket.clientname]
		if(playerlist[i] == socket.clientname)
		{
			playerlist.splice(i,1);
		}
	}
	io.sockets.emit('delplayer', playerlist, socket.clientname);
	});

});

process.on('uncaughtException', function (err) {
  console.error(err);
  console.log("Node NOT Exiting...");
});

console.log("server running");
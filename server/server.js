/* temporary */
var requestProcessor = { process : function(cmmd) { return cmmd; } };
/* */

connectedPlayers = {}; 

require('net').createServer(function (localSocket) {
    connectedPlayers[localSocket.remoteAddress] = localSocket;

    localSocket.on('data', function (data) {
        console.log(localSocket.remoteAddress + " says: " + data.toString());
        var response = requestProcessor.process(data.toString());
        localSocket.write(response);
    });

    localSocket.on('end', function() {
      console.info(localSocket.remoteAddress + ' disconnected.');
      delete connectedPlayers[localSocket.remoteAddress];
    });
})

.listen(8765);

/* temporary */
var requestProcessor = { process : function(cmmd) { return cmmd + '\n\r'; } };
/* */

connectedPlayers = {}; 

require('net').createServer(function (localSocket) {
    var remoteAddress = localSocket.remoteAddress;
    connectedPlayers[remoteAddress] = localSocket;

    localSocket.on('data', function (data) {
        console.log(remoteAddress + " says: " + data.toString());
        var response = requestProcessor.process(data.toString());
        localSocket.write(response);
    });

    localSocket.on('end', function() {
      console.info(remoteAddress + ' disconnected.');
      delete connectedPlayers[remoteAddress];
    });
})

.listen(8765);

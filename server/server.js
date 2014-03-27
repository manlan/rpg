/* temporary */
var requestProcessor = { process : function(cmmd) { return cmmd; } };
/* */

require('net').createServer(function (localSocket) {

    localSocket.on('data', function (data) {
        console.log(localSocket.remoteAddress + " says: " + data.toString());
        var response = requestProcessor.process(data.toString());
        localSocket.write(response);
    });

    localSocket.on('end', function() {
      // do something
    });
})

.listen(8765);

// client
var s = require('net').Socket();
s.connect(8765);

s.on('data', function (data) {
    console.log(data.toString());
});

s.write("Hey;");
s.write("Ho;");
s.write("Let's;");
s.write("Go;");
//s.end();

const StreamChat = require('stream-chat').StreamChat;
var mysql = require('mysql');

const user = "root"
const host = "localhost"
const password = "Bball#0128"

// Define values.
const api_key = 'hmfrcr54rrnf'
const api_secret = 'yc2zaez6cwvr6tbmqm64dr68gjqruvapcet9y2azgw7qtpzdqtvm8udmqcce2utu'

function initServer(user_id)
{
    // Initialize a Server Client
    const serverClient = StreamChat.getInstance( api_key, api_secret);
    // Create User Token
    return serverClient.createToken(user_id);
}

function queryDatabase(database, query)
{
    let con = mysql.createConnection({
        host: host,
        user: user,
        password: password,
        database: database
    });

    con.connect(function(err) {
        if(err)
        {
            throw err;
        }
        con.query(query, function(err, result){
            if(err) throw err;
            console.log(result[0].aNumber)
        });
    });
}
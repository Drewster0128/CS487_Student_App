const nodeFetch = require('node-fetch');

const StreamChat = require('stream-chat').StreamChat;
var mysql = require('mysql');

const client = StreamChat.getInstance("hmfrcr54rrnf");
// you can still use new StreamChat("api_key");

const host = "localhost";
const user = "root";
const password = "Bball#0128";
const database = "student";

function getToken(username)
{
    let ret = null;

    let con = mysql.createConnection({
        host: host,
        user: user,
        password: password,
        database: database
    });

    con.connect(function(err){
        if(err)
        {
            throw err;
        }
        con.query(`Select token from student where username = '${username}'`, function(err, result){
            if(err)
            {
                throw err;
            }
            ret = result[0].token;
        });
    });
    con.end();
    return ret;
}

function requestToken(username)
{
    fetch('http://localhost:8081', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ "id": 78912 })
    })
    .then(response => response.json())
    .then(response => console.log(JSON.stringify(response)))
}



async function connectUser(username)
{
    await client.connectUser(
        {
            id: username,
        },
        `${getToken(username)}`,
    );
}

// fetch the channel state, subscribe to future updates
async function watch(channel)
{
    await channel.watch();
}
async function sendMessage(message, channel)
{
    await channel.sendMessage({message});
}

requestToken('acook21');


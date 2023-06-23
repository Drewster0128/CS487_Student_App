const StreamChat = require('stream-chat').StreamChat;
var mysql = require('mysql');
var express = require('express');

var app = express();

const user = "root";
const host = "localhost";
const password = "Bball#0128";
const database = "student";

app.get('/', function (req, res) {
    console.log("Got a GET request");
 });

app.post('/', function(req, res)
{
    console.log("Got a POST request");
});

var server = app.listen(8080, function()
{
    var host = server.address().address;
    var port = server.address().port;

    console.log(`Example app listening at http://${host}:${port}`);
});

// Define values.
const api_key = 'hmfrcr54rrnf';
const api_secret = 'yc2zaez6cwvr6tbmqm64dr68gjqruvapcet9y2azgw7qtpzdqtvm8udmqcce2utu';

function isUser(username)
{
    return queryDatabase(`SELECT username FROM student WHERE username = '${username}'`)
        .then(function(result)
        {
            if(result.length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        });
}

function initServer(user_id)
{
    // Initialize a Server Client
    const serverClient = StreamChat.getInstance(api_key, api_secret);
    // Create User Token
    return serverClient.createToken(user_id);
}

function queryDatabase(query)
{
    return new Promise(function(resolve, reject)
    {
        let con = mysql.createConnection({
            host: host,
            user: user,
            password: password,
            database: database
        });

        con.connect(function(err)
        {
            if(err)
            {
                reject(err);
            }
            else
            {
                con.query(query, function(err, result)
                {
                    if(err)
                    {
                        reject(err);
                    }
                    else
                    {
                        resolve(result);
                        con.end();
                    }
                });
            }
        });
    });
}

function getToken(username)
{
    isUser(username)
        .then(function(bool)
        {
            queryDatabase(`SELECT token FROM student WHERE username = '${username}'`)
                .then(function(token)
                {
                    console.log(token);
                })
                .catch(function(err)
                {
                    throw err;
                });
        });
}


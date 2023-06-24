
const data = require('./user.json');
const fs = require("fs");

const StreamChat = require('stream-chat').StreamChat;
var mysql = require('mysql');


// you can still use new StreamChat("api_key");

const host = "localhost";
const user = "root";
const password = "Bball#0128";
const database = "student";

const api_key = 'hmfrcr54rrnf';
const api_secret = 'yc2zaez6cwvr6tbmqm64dr68gjqruvapcet9y2azgw7qtpzdqtvm8udmqcce2utu';

const client = StreamChat.getInstance(api_key);

function getToken(username)
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
                con.query(`SELECT token FROM student WHERE username = '${username}'`, function(err, result)
                {
                    if(err)
                    {
                        reject(err);
                    }
                    else
                    {
                        resolve(result[0].token);
                    }
                });
            }
        });
    });
}

function logIn(username)
{
    return new Promise(function(resolve, reject)
    {
        getToken(username)
        .then(function(token)
        {
            client.connectUser(
                {
                    id: username,
                },
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoiYWNvb2syMSJ9.tQw3bV1s4N-OHm47fovjdTPWOnP71x0MkZt96eXB7lY"
            ).then(function(ret)
            {
                resolve(ret);
            }).catch(function(rej)
            {
                reject(rej);
            })
        })
        .catch(function(err)
        {
            reject(err);
        });
    }); 
}

async function ChannelJSONMaker(channel)
{
    let md = await channel.query({
        messages: { limit: 20} ,
        members: { limit: 20, offset: 0 } ,
        watchers: { limit: 20, offset: 0 },
    });

    let ch = {
        channelID: md.channelID,
        members: [md.members],
        messages: [md.messages]
    };
    let data = JSON.stringify(ch);
    fs.writeFile(`${channel.id}.json`, data, function(err)
    {
        if(err)
        {
            throw err;
        }
    });
}

function getChannel(channelType, channelID)
{
    return client.getChannelById(channelType, channelID);
}

function sendMessage(username, channelType, channelID, text)
{
    logIn(username)
        .then(function(ret)
        {
            client.getChannelById(channelType, channelID).sendMessage({text: text})
                .then(function(ret)
                {
                    console.log("Message sent!");
                })
                .catch(function(err)
                {
                    console.log(err);
                });
        })
        .catch(function(rej)
        {
            console.log(rej);
        });
}

async function loadPage()
{
    await logIn("acook21");
    const filter = {members: { $in: ["acook21"] } };
    // we can also define a sort order of most recent messages first
    const sort = { last_message_at: -1 };

    let channels = await client.queryChannels(filter, sort, {watch:true});
    for(let i = 0; i < channels.length; i++)
    {
        await ChannelJSONMaker(channels[i]);
        channels[i].on("message.new", event =>
        {
            console.log(event.message.text);
        });
    }
}



loadPage();


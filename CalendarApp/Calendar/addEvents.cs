using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class addEvents : Form
    {
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
        public addEvents()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GoogleAPI()
        {
            UserCredential userCredential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            //Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = userCredential,
                ApplicationName = ApplicationName,
            });

            Event newEvent = new Event
            {
                Summary = "New Event",
                Start = new EventDateTime { DateTime = DateTime.Now.AddHours(1) },
                End = new EventDateTime { DateTime = DateTime.Now.AddHours(2) }
            };

            // Insert the event
            Event createdEvent = service.Events.Insert(newEvent, "primary").Execute();

        }

        private void add_Click(object sender, EventArgs e)
        {
            //GoogleAPI(); Current does not work as permissions haven't been approved yet but code is laid out for a basic function of adding events
            Close();
        }
    }
}

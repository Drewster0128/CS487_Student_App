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
    public partial class deleteEvents : Form
    {
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";

        public deleteEvents()
        {
            InitializeComponent();
            eventstxtbox.Text = events.eventlist;
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

            // Specify the event ID to be deleted
            string eventId = "YOUR_EVENT_ID";

            // Delete the event
            service.Events.Delete("primary", eventId).Execute();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            //GoogleAPI(); Does not work as permissions haven't been approved yet but the code is laid out for a basic delete event function
            Close();
        }

    }
}

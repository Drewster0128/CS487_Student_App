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
    public partial class events : Form
    {
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";

        public static string eventlist;

        public events()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void events_Load(object sender, EventArgs e)
        {
            txtdate.Text = calendar.static_month + "/" + UserControlDays.static_day + "/" + calendar.static_year;
            GoogleAPI();
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

            int currentday = int.Parse(UserControlDays.static_day);

            //Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = new DateTime(calendar.static_year, calendar.static_month, currentday, 0, 0, 0, 0);
            request.TimeMax = new DateTime(calendar.static_year, calendar.static_month, currentday + 1, 0, 0, 0, 0);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 5;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            if (events.Items != null && events.Items.Count > 0)
            {
                eventstxtbox.Text = "";

                foreach (var eventItem in events.Items)
                {
                    eventstxtbox.Text += eventItem.Summary + Environment.NewLine;
                }
            }
            else
            {
                eventstxtbox.Text = "No Events";
            }

            eventlist = eventstxtbox.Text;
        }

        private void addevent_Click(object sender, EventArgs e)
        {
            addEvents f = new addEvents();
            Hide();
            f.ShowDialog();
            Close();
        }

        private void deleteEvent_Click(object sender, EventArgs e)
        {
            deleteEvents f = new deleteEvents();
            Hide();
            f.ShowDialog();
            Close();
        }
    }
}

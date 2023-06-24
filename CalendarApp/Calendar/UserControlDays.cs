using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class UserControlDays : UserControl
    {
        public static string static_day;

        public UserControlDays()
        {
            InitializeComponent();
        }

        public void days(int numdays)
        {
            gdays.Text = numdays + "";
            string currentdate = DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
            string currentbox = calendar.static_month + "/" + numdays + "/" + calendar.static_year;
            if(currentdate == currentbox)
            {
                gdays.BackColor = Color.LightBlue;
            }
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = gdays.Text;
            events f = new events();
            f.Show();

        }
    }
}

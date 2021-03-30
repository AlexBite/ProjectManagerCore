using ProjectManagerCore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class AddTypeOfActivity : Form
    {
        private readonly IActivityService _activityService;
        public AddTypeOfActivity()
        {
            _activityService = new ActivityService();
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var activityName = ActivityNameBox.Text;
            _activityService.AddActivity(activityName);
            this.Close();
        }
    }
}

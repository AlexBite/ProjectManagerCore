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
    public partial class AddJobForm : Form
    {
        private readonly IPositionService _positionService;
        public AddJobForm()
        {
            _positionService = new PositionService();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var positionName = textBox1.Text;
            _positionService.AddPosition(positionName);
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session1
{
    public partial class EmployeeManagement : Form
    {
        public long UserID {  get; set; }
        public EmployeeManagement(long userID)
        {
            InitializeComponent();
            this.UserID = userID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UserID = 0;
            Properties.Settings.Default.IsEmployee = false;

            Properties.Settings.Default.Save();
            this.Hide();
            new Form1().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

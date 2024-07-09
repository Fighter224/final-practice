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
    public partial class Form1 : Form
    {
        public WSCEntities ent {  get; set; }
        public Form1()
        {
            InitializeComponent();
            ent = new WSCEntities();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox3.UseSystemPasswordChar = !this.checkBox2.Checked;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            new CreateAccountForm().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //login

            if(string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("User field could be blank");
                return;
            }

            var userTypeId = !string.IsNullOrEmpty(textBox1.Text) ? 1 : 2;

            var login = ent.Users.ToList().FirstOrDefault(x =>
                x.Username == (userTypeId == 1 ? textBox1.Text : textBox2.Text) &&
                x.Password == textBox3.Text && x.UserTypeID == userTypeId

            );

            

            if(userTypeId == 1)
            {

                var user = ent.Users.FirstOrDefault(x => x.Username == textBox2.Text && x.UserTypeID == 2);

                if (login == null)
                {
                    MessageBox.Show("User is not found");
                    return;
                }

                if(checkBox1.Checked)
                {
                    Properties.Settings.Default.UserID = user.ID;
                    Properties.Settings.Default.IsEmployee = true;

                    Properties.Settings.Default.Save();
                }

                this.Hide();
                new EmployeeManagement(login.ID).ShowDialog();
            }
            else
            {
                if (checkBox1.Checked)
                {
                    Properties.Settings.Default.UserID = login.ID;
                    Properties.Settings.Default.IsEmployee = true;

                    Properties.Settings.Default.Save();
                }

                this.Hide();
                new UserManagement(login.ID).ShowDialog();
            }
            
        }
    }
}

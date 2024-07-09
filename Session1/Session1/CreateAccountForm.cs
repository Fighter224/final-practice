using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session1
{
    public partial class CreateAccountForm : Form
    {
        public WSCEntities ent {  get; set; }
        public CreateAccountForm()
        {
            InitializeComponent();
            ent = new WSCEntities();
            radioButton1.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                numericUpDown1.Value <= 0 )
            {

            }

            if(textBox3.Text.Length < 5)
            {
                MessageBox.Show("Password must be more than 5 characters");
                return;
            }

            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("The password type is not the same");
                return;
            }

            if(ent.Users.Any(x => x.Username == textBox1.Text))
            {
                MessageBox.Show("The username is already regitered");
                return;
            }

            var user = new User()
            {
                Username = textBox1.Text,
                Password = textBox3.Text,
                FullName = textBox2.Text,
                BirthDate = dateTimePicker1.Value,
                FamilyCount = (int)numericUpDown1.Value,
                Gender = radioButton1.Checked,
                UserTypeID = 2,
                GUID = Guid.NewGuid(),

            };

            ent.Users.Add(user);
            ent.SaveChanges();

            this.Hide();

            new UserManagement(user.ID).ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string text = File.ReadAllText("Terms.txt");
            MessageBox.Show(text);
            isRead = true;
        }



        bool isRead = false;
    }
}

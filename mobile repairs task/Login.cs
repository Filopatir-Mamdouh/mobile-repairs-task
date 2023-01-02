using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mobile_repairs_task
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (username.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else if (username.Text == "Admin" && pass.Text == "admin")
            {
                Repairs obj = new Repairs();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Data");
                username.Text = "";
                pass.Text = "";
            }
        }
    }
}

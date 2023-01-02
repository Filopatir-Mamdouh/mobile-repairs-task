using System;
using System.Collections;
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
    public partial class Spares : Form
    {
        Functions con;
        private string query="";
        public Spares()
        {
            InitializeComponent();
            con = new Functions();
            showSpares();
        }
        private void showSpares()
        {
            query = "SELECT * FROM sparetb";
            sparelist.DataSource = con.getData(query);
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            if (PartName.Text == "" || Cost.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                string name = PartName.Text;
                int cost = Convert.ToInt32(Cost.Text);
                query = "INSERT INTO sparetb VALUES('" + name + "'," + cost + ")";
                int r = con.setData(query);
                MessageBox.Show("Spare Added Successfully");
                showSpares();
                clear();

            }
        }
        int key = 0;
        private void sparelist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PartName.Text = sparelist.SelectedRows[0].Cells[1].Value.ToString();
            Cost.Text = sparelist.SelectedRows[0].Cells[2].Value.ToString();
            if (PartName.Text == "")
            {
                key = 0;
            }
            else
                key = Convert.ToInt32(sparelist.SelectedRows[0].Cells[0].Value.ToString());
        }
        private void clear()
        {
            PartName.Text = "";
            Cost.Text = "";
            key = 0;
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (PartName.Text == "" || Cost.Text == "" || key == 0)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                string name = PartName.Text;
                int cost = Convert.ToInt32(Cost.Text);
                query = "UPDATE sparetb SET SpName = '" + name + "', SpCost = " + cost + " WHERE SpID =" + key;
                int r = con.setData(query);
                MessageBox.Show("Spare Updated :D");
                clear();
                showSpares();
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please Select a Spare Part");
            }
            else
            {
                query = "DELETE FROM sparetb WHERE SpID=" + key;
                int r = con.setData(query);
                MessageBox.Show("Spare Deleted!!");
                clear();
                showSpares();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Spares obj = new Spares();
            obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Repairs obj = new Repairs();
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();
        }
    }
}

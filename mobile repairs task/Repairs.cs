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
    public partial class Repairs : Form
    {
        Functions con;
        string query = "";
        public Repairs()
        {
            InitializeComponent();
            con = new Functions();
            showRepairs();
            getCustomers();
            getspares();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void getCustomers()
        {
            query = "SELECT * FROM customertb";
            cust.DisplayMember = con.getData(query).Columns["CustName"].ToString();
            cust.ValueMember = con.getData(query).Columns["CustID"].ToString();
            cust.DataSource = con.getData(query);
            query = "";
        }
        private void getspares()
        {
            query = "SELECT * FROM sparetb";
            spare.DisplayMember = con.getData(query).Columns["SpName"].ToString();
            spare.ValueMember = con.getData(query).Columns["SpID"].ToString();
            spare.DataSource = con.getData(query);
            query = "";
        }
        private void getCost()
        {
                query = "SELECT * FROM sparetb WHERE SpID = " + spare.SelectedValue.ToString();
                foreach (DataRow dr in con.getData(query).Rows)
                {
                    sparecost.Text = dr["SpCost"].ToString();
                }
            
        }

        private void showRepairs()
        {
            query = "SELECT * FROM reptb";
            replist.DataSource = con.getData(query);
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            if (cust.SelectedIndex == -1 || phone.Text == "" || dname.Text == "" || dmodel.Text == "" || problem.Text == "" || sparecost.Text == "" || totalcost.Text == "" || spare.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                string date = repDate.Value.Date.ToString();
                int custcb = Convert.ToInt32(cust.SelectedValue.ToString());
                string phone = this.phone.Text;
                string dname = this.dname.Text;
                string dmodel = this.dmodel.Text;
                string problem = this.problem.Text;
                int spare = Convert.ToInt32(this.spare.SelectedValue.ToString());
                int spcost =Convert.ToInt32(sparecost.Text);
                int repaircost = Convert.ToInt32(this.totalcost.Text);
                int totalcost = spcost + repaircost;
                query = "INSERT INTO reptb VALUES('{0}',{1},'{2}','{3}','{4}','{5}',{6},{7})";
                query = String.Format(query,date,custcb,phone,dname,dmodel,problem,spare,totalcost);
                int r = con.setData(query);
                MessageBox.Show("Repair Added Successfully");
                showRepairs();
                clear();

            }
        }
        int key = 0;
        private void replist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(replist.SelectedRows[0].Cells[0].Value.ToString());
        }
        private void clear()
        {
            query = "";
            phone.Text = "";
            dname.Text = "";
            dmodel.Text = "";
            problem.Text = "";
            totalcost.Text = "";
            key = 0;
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please Select a Repair");
            }
            else
            {
                query = "DELETE FROM reptb WHERE RepCode=" + key;
                int r = con.setData(query);
                MessageBox.Show("Repair Deleted!!");
                showRepairs();
            }
        }
        private void spare_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getCost();
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

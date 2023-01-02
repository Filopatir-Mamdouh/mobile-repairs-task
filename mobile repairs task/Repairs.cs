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
        string query;
        public Repairs()
        {
            InitializeComponent();
            con = new Functions();
            showRepairs();
            getCustomers();
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
                int totalcost = Convert.ToInt32(this.totalcost.Text);
                query = "INSERT INTO reptb VALUES('{0}',{1},'{2}','{3}','{4}','{5}',{7})";
                String.Format(query,date,custcb,phone,dname,dmodel,problem,spare,totalcost);
                int r = con.setData(query);
                MessageBox.Show("Repair Added Successfully");
                showRepairs();
                clear();

            }
        }
        int key = 0;
        private void replist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustName.Text = replist.SelectedRows[0].Cells[1].Value.ToString();
            CustAdd.Text = replist.SelectedRows[0].Cells[3].Value.ToString();
            CustPhone.Text = replist.SelectedRows[0].Cells[2].Value.ToString();
            if (CustName.Text == "")
            {
                key = 0;
            }
            else
                key = Convert.ToInt32(replist.SelectedRows[0].Cells[0].Value.ToString());
        }
        private void clear()
        {
            query = "";
            cust.SelectedIndex = -1;
            phone.Text = "";
            dname.Text = "";
            dmodel.Text = "";
            problem.Text = "";
            sparecost.Text = "";
            totalcost.Text = "";
            spare.SelectedIndex = -1;
            key = 0;
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (CustName.Text == "" || CustPhone.Text == "" || CustAdd.Text == "" || key == 0)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                string name = CustName.Text;
                string phone = CustPhone.Text;
                string add = CustAdd.Text;
                query = "UPDATE reptb SET CustName = '" + name + "', CustPhone = '" + phone + "', CustAdd = '" + add + "' WHERE CustID =" + key;
                int r = con.setData(query);
                MessageBox.Show("Repair Updated :D");
                clear();
                showRepairs();
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please Select a Repair");
            }
            else
            {
                query = "DELETE FROM reptb WHERE CustID=" + key;
                int r = con.setData(query);
                MessageBox.Show("Repair Deleted!!");
                clear();
                showRepairs();
            }
        }
    }
}

namespace mobile_repairs_task
{
    public partial class Customers : Form
    {
        Functions con;
        private string query="";
        public Customers()
        {
            InitializeComponent();
            con = new Functions();
            showCustomers();
        }
        private void showCustomers()
        {
            query = "SELECT * FROM customertb";
            customerlist.DataSource= con.getData(query);
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
           if (CustName.Text == "" || CustPhone.Text == "" || CustAdd.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                string name = CustName.Text;
                string phone = CustPhone.Text; 
                string add = CustAdd.Text;
                query = "INSERT INTO customertb VALUES('" + name + "','" + phone + "','" + add + "')";
                int r = con.setData(query);
                MessageBox.Show("Customer Added Successfully");
                showCustomers();
                clear();

            }
        }
        int key = 0;
        private void customerlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustName.Text= customerlist.SelectedRows[0].Cells[1].Value.ToString();
            CustAdd.Text= customerlist.SelectedRows[0].Cells[3].Value.ToString();
            CustPhone.Text = customerlist.SelectedRows[0].Cells[2].Value.ToString();
            if (CustName.Text == "")
            {
                key = 0;
            }
            else 
                key= Convert.ToInt32(customerlist.SelectedRows[0].Cells[0].Value.ToString());
        }
        private void clear()
        {
            CustName.Text = "";
            CustPhone.Text = "";
            CustAdd.Text = "";
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
                query = "UPDATE customertb SET CustName = '" + name + "', CustPhone = '" + phone + "', CustAdd = '" + add + "' WHERE CustID ="+key;
                int r = con.setData(query);
                MessageBox.Show("Customer Updated :D");
                clear();
                showCustomers();
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please Select a Customer");
            }
            else
            {
                query = "DELETE FROM customertb WHERE CustID=" + key;
                int r = con.setData(query);
                MessageBox.Show("Customer Deleted!!");
                clear();
                showCustomers();
            }
        }
    }
}
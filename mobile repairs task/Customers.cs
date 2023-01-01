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
                try
                {
                    int r = con.setData(query);
                    MessageBox.Show("Customer Added Successfully");
                    showCustomers();
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile_repairs_task
{
    class Functions
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string constr;

        public Functions()
        {
            constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nour\Documents\mrsDb.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(constr);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public DataTable getData(string query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(query, con);
            sda.Fill(dt);
            return dt;
        }

        public int setData(string query)
        {
            int r = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = query;
            r = cmd.ExecuteNonQuery();
            con.Close();
            return r;
        }
    }
}

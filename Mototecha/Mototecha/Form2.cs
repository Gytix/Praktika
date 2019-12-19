using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mototecha
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void Button1_Click(object sender, EventArgs e)
        {


            

            /*string conString = @"Data Source = DESKTOP - FGH8R19\SQLEXPRESS; Initial Catalog = DB_Practice; Integrated Security = True";

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            MessageBox.Show("Connected");

            String sqlSelectQuery = "SELECT * FROM DB_Practice WHERE ID = " + 1 ;
            SqlCommand cmd = new SqlCommand(sqlSelectQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label19.Text = (dr["Gamintojas"].ToString());

            }
            con.Close();*/
        }
    }
}

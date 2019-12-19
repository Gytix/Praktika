using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Mototecha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {
            

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();





            Database duombaze = new Database();
           
            string querry = "SELECT * FROM `dalys`";
           
            MySqlCommand myCommand = new MySqlCommand(querry, duombaze.myDatabase);
             duombaze.Open(); //prisijungus prie db ja atidaro
            MySqlDataReader resultInfo = myCommand.ExecuteReader();
            if (resultInfo.HasRows)
            {
                while (resultInfo.Read())
                {
                    MessageBox.Show("Prisijungta");
                }
            }
            else
            {
            MessageBox.Show("Neprisijunge");
            }
            duombaze.Close();


            /*string conString = "Data Source = DESKTOP - FGH8R19\\SQLEXPRESS; Initial Catalog = DB_Practice; Integrated Security = True";

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            MessageBox.Show("Connected");

            String sqlSelectQuery = "SELECT * FROM DB_Practice WHERE ID = "+ int.Parse(textBox1.Text);
            SqlCommand cmd = new SqlCommand(sqlSelectQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = (dr["Gamintojas"].ToString());

            }
            con.Close();*/


            //Data Source = DESKTOP - FGH8R19\SQLEXPRESS; Initial Catalog = DB_Practice; Integrated Security = True

            /*SqlConnection myDatabase = new SqlConnection();
              myDatabase.Open();

            if (cons)

            myDatabase.Close(); */



        }

          private void Label5_Click(object sender, EventArgs e)
          {

          }
      }
  }

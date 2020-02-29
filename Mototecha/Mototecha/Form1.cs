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

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //kurt trecia forma dalim ir sita i daliu forma perkelt

            List<string> dalisPavadinimas = new List<string>();
            List<int> dalisGamintojoID = new List<int>();
            List<int> dalisKaina = new List<int>();

            Database duombaze = new Database();
            duombaze.Open(); //prisijungus prie db ja atidaro

            string querry2 = "SELECT * FROM `dalys`";
            MySqlCommand myCommand2 = new MySqlCommand(querry2, duombaze.myDatabase);
            var reader2 = myCommand2.ExecuteReader(); //dbopen nereik nes jau atidaryta
            while (reader2.Read())
            {
                dalisPavadinimas.Add(reader2[1].ToString());
                dalisKaina.Add(reader2.GetInt32(3));
            }
            duombaze.Close();
        }
    }
  }

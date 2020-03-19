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
    public partial class regForma : Form
    {
        public regForma()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
            Database duombaze = new Database();
            if (textBox2.Text == textBox3.Text)
            {
                string insertQuery = "INSERT INTO praktikai.vartotojas(PrisijungimoVardas, PrisijungimoSlaptazodis, Admin) VALUES('"
                                                                               + textBox1.Text + "','" + textBox2.Text + "','" + 0 + "')";
                duombaze.Open();
               
                MySqlCommand myCommand = new MySqlCommand(insertQuery, duombaze.myDatabase);
                if (myCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Prisiregistruota, galite prisijungti");
                }
                else
                {
                    MessageBox.Show("Neprisiregistruota, problemos su duomenu baze");
                }
            }
            else
            {
                MessageBox.Show("Slaptazodziai skiriasi", "Patikrinkite slaptazodzius");
            }
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            logInForma log = new logInForma();
            log.Show();
        }
    }
}

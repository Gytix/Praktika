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
    public partial class dalysAdmin : Form
    {
        int privilegija;
        public dalysAdmin(int privilegija)
        {
            this.privilegija = privilegija;
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 pradinis = new Form1(privilegija);
            pradinis.Show();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && textBox1.Text != null && textBox2.Text != null && textBox3.Text != null )
            {
                button1.Enabled = true;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                button2.Enabled = true;
            }
        }   

        private void Button1_Click(object sender, EventArgs e)
        {
            Database duombaze = new Database();
            string insertQuery = "INSERT INTO praktikai.dalys(Pavadinimas, Kaina, Tinkamumas)" +  
                                 "VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";

            duombaze.Open();

            MySqlCommand myCommand = new MySqlCommand(insertQuery, duombaze.myDatabase);
            if (myCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Motociklo įkėlimas sėkmingas");
            }
            else
            {
                MessageBox.Show("Motociklo įkėlimas nesėkmingas");
            }
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 pradinis = new Form1(privilegija);
            pradinis.Show();
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                button3.Enabled = true;
            }
        }
    }
}

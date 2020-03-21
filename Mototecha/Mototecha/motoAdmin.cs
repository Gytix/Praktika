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
    public partial class motoAdmin : Form
    {
        int privilegija;
        public motoAdmin(int privilegija) 
        {
            this.privilegija = privilegija;
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && textBox1.Text != null && textBox2.Text != null && textBox3.Text != null &&
                textBox4.Text != null && textBox5 != null && textBox6.Text != null && textBox7 != null && textBox8 != null)
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
                string insertQuery = "INSERT INTO praktikai.motociklas(Tipas, Gamintojas, Modelis, Metai, Spalva, Kubatura, Rida, Kaina)" +
                "VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" 
                + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')";

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

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 pradinis = new Form1(privilegija);
            pradinis.Show();
        }
    }
}

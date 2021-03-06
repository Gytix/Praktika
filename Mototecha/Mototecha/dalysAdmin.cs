﻿using System;
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
        List<Dalys> dalys = new List<Dalys>();
        public dalysAdmin(int privilegija)
        {
            this.privilegija = privilegija;
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            
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
            if (checkBox2.Checked == true && textBox4.Text != null && textBox5.Text != null && textBox6.Text != null)
            {
                button2.Enabled = true;
            }
        }   

        private void Button1_Click(object sender, EventArgs e) //ikelimas
        {
            Database duombaze = new Database();
            string insertQuery = "INSERT INTO praktikai.dalys(Pavadinimas, Kaina, Tinkamumas)" +  
                                 "VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";

            duombaze.Open();

            MySqlCommand myCommand = new MySqlCommand(insertQuery, duombaze.myDatabase);
            if (myCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Dalies įkėlimas sėkmingas");
            }
            else
            {
                MessageBox.Show("Dalies įkėlimas nesėkmingas");
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
                button4.Enabled = true;
            }
        }

        private void Button5_Click(object sender, EventArgs e) //db uzkrovimas
        {
            Database duombaze = new Database();
            string querry = "SELECT * FROM `dalys`";

            MySqlCommand myCommand = new MySqlCommand(querry, duombaze.myDatabase);
            duombaze.Open();

            var reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                Dalys Dalis = new Dalys();
                Dalis.pavadinimas = reader["Pavadinimas"].ToString();
                Dalis.kaina = Convert.ToInt32(reader["Kaina"]);
                Dalis.tinkamumas = reader["Tinkamumas"].ToString();
                dalys.Add(Dalis);
            }
            dalys.Sort();

            comboBox1.DataSource = dalys;
            comboBox4.DataSource = dalys;
            comboBox5.DataSource = dalys;
            comboBox6.DataSource = dalys;

            comboBox1.DisplayMember = "pavadinimas";
            comboBox4.DisplayMember = "pavadinimas";
            comboBox5.DisplayMember = "kaina";
            comboBox6.DisplayMember = "tinkamumas";

            comboBox1.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            duombaze.Close();
        }

        private void Button4_Click(object sender, EventArgs e) //istrinti
        {
            Database duombaze = new Database();
            string istrynimui = comboBox4.Text;
            string deleteQuerry = "DELETE FROM `dalys` WHERE Pavadinimas= '" + istrynimui + "';";
            duombaze.Open(); //prisijungus prie db ja atidaro

            MySqlCommand myCommand = new MySqlCommand(deleteQuerry, duombaze.myDatabase);

            if (myCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Dalies istrynimas sėkmingas");
            }
            else
            {
                MessageBox.Show("Dalies istrynimas nesėkmingas");
            }

            duombaze.Close();
        }

        private void Button2_Click(object sender, EventArgs e) //keitimas dalies
        {  //db pakeicia kaip ir nurodoma, bet execute visada 0
            Database duombaze = new Database();
            string pakeitimui = comboBox1.Text;
            string query = "UPDATE `dalys` SET Pavadinimas=@Pavadinimas,Kaina=@Kaina, Tinkamumas =@Tinkamumas " +
                "WHERE Pavadinimas= '" + pakeitimui + "';";
            duombaze.Open();
            MySqlCommand myCommand = new MySqlCommand(query, duombaze.myDatabase);
            myCommand.CommandText = query;
            myCommand.Parameters.AddWithValue("@Pavadinimas", textBox6.Text);
            myCommand.Parameters.AddWithValue("@Kaina", Convert.ToInt32(textBox5.Text));
            myCommand.Parameters.AddWithValue("@Tinkamumas", textBox4.Text);
            myCommand.ExecuteNonQuery();

            if (myCommand.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Dalies duomenų pakeitimas sėkmingas");
            }
            else
            {
                MessageBox.Show("Dalies duomenų pakeitimas nesėkmingas");
            }
            duombaze.Close();
        }
    }
}

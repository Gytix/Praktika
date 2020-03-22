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
        List<NaujiM> motoRedagavimui = new List<NaujiM>();
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

        private void Button1_Click(object sender, EventArgs e) //ikelimas
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

        private void Button5_Click(object sender, EventArgs e) //nuskaitymas
        {
            Database duombaze = new Database();

            string querry = "SELECT * FROM `motociklas`";
            MySqlCommand myCommand = new MySqlCommand(querry, duombaze.myDatabase);
            duombaze.Open(); //prisijungus prie db ja atidaro
            var reader = myCommand.ExecuteReader();
            
            while (reader.Read())
            {
                NaujiM Mocas = new NaujiM();
                Mocas.gamintojas = reader["Gamintojas"].ToString();
                Mocas.modelis = reader["Modelis"].ToString();
                Mocas.tipas = reader["Tipas"].ToString();
                Mocas.metai = Convert.ToInt32(reader["Metai"]);
                Mocas.kaina = Convert.ToInt32(reader["Kaina"]);
                Mocas.spalva = reader["Spalva"].ToString();
                Mocas.kubatura = Convert.ToInt32(reader["Kubatura"]);
                Mocas.rida = Convert.ToInt32(reader["Rida"]);
                motoRedagavimui.Add(Mocas);
            }
            motoRedagavimui.Sort();

            comboBox1.DataSource = motoRedagavimui;
            comboBox2.DataSource = motoRedagavimui;//delete
            comboBox9.DataSource = motoRedagavimui;//delete
            comboBox12.DataSource = motoRedagavimui;//delete

            comboBox1.DisplayMember = "pilnasPavadinimas";
            comboBox2.DisplayMember = "pilnasPavadinimas";//delete
            comboBox9.DisplayMember = "Gamintojas";//delete
            comboBox12.DisplayMember = "Modelis";//delete

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1; //delete
            comboBox9.SelectedIndex = -1; //delete
            comboBox12.SelectedIndex = -1; //delete

            

            //comboBox9.SelectedIndex = -1;
            //comboBox12.SelectedIndex = -1;
            duombaze.Close();
        }

        private void Button4_Click(object sender, EventArgs e) //istrynimas
        {
            Database duombaze = new Database();
            string istrynimui = comboBox12.Text;
            string deleteQuerry = "DELETE FROM `motociklas` WHERE Modelis= '" + istrynimui + "';";
            duombaze.Open(); //prisijungus prie db ja atidaro
            
            MySqlCommand myCommand = new MySqlCommand(deleteQuerry, duombaze.myDatabase);
            myCommand.Parameters.AddWithValue("@Modelis", this.comboBox12.SelectedItem);

            if (myCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Motociklo istrynimas sėkmingas");
            }
            else
            {
                MessageBox.Show("Motociklo istrynimas nesėkmingas");
            }
            
            duombaze.Close();
        }

        private void ComboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                button4.Enabled = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e) //keitimas
        {
            Database duombaze = new Database();
            string pakeitimui = comboBox12.Text;
            string query = "UPDATE `motociklas` SET Tipas=@Tipas, Gamintojas=@Gamintojas, Modelis=@Modelis," +
            "Metai=@Metai, Kaina=@Kaina, Spalva=@Spalva, Kubatura=@Kubatura, Rida=@Rida WHERE " +
                "Modelis= '" + pakeitimui + "';";
            duombaze.Open();
            MySqlCommand myCommand = new MySqlCommand(query, duombaze.myDatabase);
            myCommand.CommandText = query;
            myCommand.Parameters.AddWithValue("@Tipas", textBox16.Text);
            myCommand.Parameters.AddWithValue("@Gamintojas", textBox15.Text);
            myCommand.Parameters.AddWithValue("@Modelis", textBox14.Text);
            myCommand.Parameters.AddWithValue("@Metai", textBox13.Text); 
            myCommand.Parameters.AddWithValue("@Spalva", textBox12.Text);
            myCommand.Parameters.AddWithValue("@Kubatura", textBox11.Text);
            myCommand.Parameters.AddWithValue("@Rida", textBox10.Text);
            myCommand.Parameters.AddWithValue("@Kaina", textBox9.Text);

            myCommand.ExecuteNonQuery();

            if (myCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Motociklo duomenų pakeitimas sėkmingas");
            }
            else
            {
                MessageBox.Show("Motociklo duomenų nesėkmingas");
            }
            //myConnection.Close();
            duombaze.Close();
        }
    }
}

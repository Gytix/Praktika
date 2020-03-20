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
    public partial class logInForma : Form
    {
        public logInForma()
        {
            InitializeComponent();
        }

        private void LogInForma_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Database duombaze = new Database();
            vartotojas Vartotojas = new vartotojas();
            duombaze.Open();
            string querry = "SELECT * FROM `vartotojas` WHERE PrisijungimoVardas = '" + tBvardas.Text.Trim() + "' AND PrisijungimoSlaptazodis = '" + tBslaptazodis.Text.Trim() + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(querry, duombaze.myDatabase);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            int privilegija;
            if (dtbl.Rows.Count == 1)
            {
                Vartotojas.vardas = tBvardas.Text;
                Vartotojas.slaptazodis = tBslaptazodis.Text;

                if (Vartotojas.vardas == "Gytyx" && Vartotojas.slaptazodis == "qwerty") //patobulint
                {
                    privilegija = 1;
                }
                else
                {
                    privilegija = 0;
                }
                 
                Form1 Pagrindinis = new Form1(privilegija);
                this.Hide();
                Pagrindinis.Show();
            }
            else
            {
                MessageBox.Show("Patikrinkite ivestus duomenis", "Neteisingas prisijungimas");
            }
            duombaze.Close();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            regForma registracija = new regForma();
            this.Hide();
            registracija.Show();

        }
    }
}

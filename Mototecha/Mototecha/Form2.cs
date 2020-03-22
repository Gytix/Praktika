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

    public partial class Form2 : Form
    {
        int privilegija;
        List<NaujiM> NMList = new List<NaujiM>();
        //public System.Windows.Forms.ComboBox.ObjectCollection Items { get; } //kad pridet i combo box listus
        //public object NaudotuMList { get; private set; }
        //internal List<NaujiM> NMList { get; private set; }
        //List<Customers> new_customer = new List<Customers>();

        //public object NaudotuMList { get; private set; }

        public Form2(int privilegija)
        {
            InitializeComponent();
            button4.Enabled = false;
            this.privilegija = privilegija;
            label6.Text = privilegija.ToString();
            if (privilegija == 1)
            {
                button4.Enabled = true;
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                MessageBox.Show("Dėl bandomojo važiavimo arba motociklo pirkimo kreipkitės elektroniniu paštu uzsakymai@mototecha.com");
            }
            else
            {
                MessageBox.Show("Pasirinkite motociklą, prieš tai užkraudami duombazę");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
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
                NMList.Add(Mocas);
                
            }
                NMList.Sort();

            comboBox1.DataSource = NMList;
            comboBox3.DataSource = NMList;
            comboBox4.DataSource = NMList;
            comboBox5.DataSource = NMList;
            comboBox6.DataSource = NMList;
            comboBox7.DataSource = NMList;
            comboBox8.DataSource = NMList;
            comboBox10.DataSource = NMList;
            comboBox11.DataSource = NMList;
            comboBox1.DisplayMember = "pilnasPavadinimas";
            comboBox3.DisplayMember = "tipas";
            comboBox4.DisplayMember = "gamintojas";
            comboBox5.DisplayMember = "modelis";
            comboBox6.DisplayMember = "metai";
            comboBox7.DisplayMember = "spalva";
            comboBox8.DisplayMember = "kubatura";
            comboBox10.DisplayMember = "rida";
            comboBox11.DisplayMember = "kaina";

            //kad užkrovus db, neišmestų pirmo liste ir jo charakteristikų
            comboBox1.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox7.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;
            comboBox10.SelectedIndex = -1;
            comboBox11.SelectedIndex = -1;
            duombaze.Close();
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 pradinis = new Form1(privilegija);
            pradinis.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            motoAdmin adminMoto = new motoAdmin(privilegija);
            //adminMoto.recieve(NMList);
            adminMoto.Show();
        }
    }
}

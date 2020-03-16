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
    public partial class daliuForma : Form
    {
        public daliuForma()
        {
            InitializeComponent();
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
            List<Dalys> dalys = new List<Dalys>();
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
            comboBox2.DataSource = dalys;
            comboBox3.DataSource = dalys;
            comboBox4.DataSource = dalys;

            comboBox1.DisplayMember = "pavadinimas";
            comboBox2.DisplayMember = "pavadinimas";
            comboBox3.DisplayMember = "kaina";
            comboBox4.DisplayMember = "tinkamumas";

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            duombaze.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 pradinis = new Form1();
            pradinis.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != -1)
            {
                MessageBox.Show("Dėl detalių užsakymų kreipkitės elektroniniu paštu uzsakymai@mototecha.com");
            }
            else
            {
                MessageBox.Show("Pasirinkite detalę, prieš tai užkraudami duombazę");
            }
        }
    }
}

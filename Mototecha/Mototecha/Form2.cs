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
        public Form2()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            List<string> motoTipas = new List<string>();
            List<string> motoGamintojas = new List<string>();
            List<string> motoModelis = new List<string>();
            List<int> motoMetai = new List<int>();
            List<int> motoKaina = new List<int>();
            List<string> motoSpalva = new List<string>();
            List<int> motoKubatura = new List<int>();
            List<int> motoRida = new List<int>();
            List<int> motoID = new List<int>();

            

            Database duombaze = new Database();
            string querry = "SELECT * FROM `motociklas`";
            MySqlCommand myCommand = new MySqlCommand(querry, duombaze.myDatabase);
            duombaze.Open(); //prisijungus prie db ja atidaro
            var reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                motoTipas.Add(reader[1].ToString());
                motoGamintojas.Add(reader[2].ToString());
                motoModelis.Add(reader[3].ToString());
                motoMetai.Add(reader.GetInt32(4));
                motoKaina.Add(reader.GetInt32(5));
                motoSpalva.Add(reader[6].ToString());
                motoKubatura.Add(reader.GetInt32(7));
                motoRida.Add(reader.GetInt32(8));
                motoID.Add(reader.GetInt32(9));
                //label = reader[0] (CIA ID)
                /*label16.Text = reader[1].ToString(); //tipas
                label19.Text = reader[2].ToString(); //gamintojas
                label20.Text = reader[3].ToString(); //modelis

                label21.Text = reader[4].ToString(); //metai
                label22.Text = reader[5].ToString(); //kaina
                label23.Text = reader[6].ToString(); //spalva
                label24.Text = reader[7].ToString(); //kubatura
                label25.Text = reader[8].ToString(); //rida
                label26.Text = reader[9].ToString(); //modelio id*/
            }
            /*string querry2 = "SELECT * FROM `dalys`";
            MySqlCommand myCommand2 = new MySqlCommand(querry2, duombaze.myDatabase); 
            var reader2 = myCommand2.ExecuteReader(); //dbopen nereik nes jau atidaryta
            while (reader2.Read())
            {
                dalisPavadinimas.Add(reader2[1].ToString());
                dalisKaina.Add(reader2.GetInt32(3));

            }/
                /*if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageBox.Show("Prisijungta");
                    }
                }

                else
                {
                    MessageBox.Show("Neprisijungta");
                }*/

                duombaze.Close();
        }
    }
}

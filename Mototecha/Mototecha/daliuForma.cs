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
            List<string> dalisPavadinimas = new List<string>();
            List<int> dalisGamintojoID = new List<int>();
            List<int> dalisKaina = new List<int>();

            Database duombaze = new Database();
            string querry = "SELECT * FROM `dalys`";
            MySqlCommand myCommand = new MySqlCommand(querry, duombaze.myDatabase);
            duombaze.Open(); //prisijungus prie db ja atidaro
            
            var reader2 = myCommand.ExecuteReader(); //dbopen nereik nes jau atidaryta
            while (reader2.Read())
            {
                dalisPavadinimas.Add(reader2[1].ToString());
                dalisKaina.Add(reader2.GetInt32(3));
            }
            duombaze.Close();
        }
    }
}

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
    public partial class Form1 : Form
    {
        int privilegija;
        public Form1(int privilegija)
        {
            InitializeComponent();
            this.privilegija = privilegija;
            if (privilegija == 1)
            {
                label7.Text = "Administratoriaus";
            }
            else
            {
                label7.Text = "Paprasto vartotojo";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {
            

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2(privilegija); //mocu forma
            form2.Show();
        }

          private void Label5_Click(object sender, EventArgs e)
          {

          }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            daliuForma form3 = new daliuForma(privilegija);
            form3.Show();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            logInForma log = new logInForma();
            log.Show();
        }
    }
  }

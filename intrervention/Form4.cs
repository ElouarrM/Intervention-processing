using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intrervention
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="Admin" && textBox2.Text == "4321")
            {
                Form3 f = new Form3();
                f.ShowDialog();
                textBox1.Text = "";
                textBox2.Text = "";
              
            }
            else
            {
                MessageBox.Show("votre mot de passe ou Nom est incorecte");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}

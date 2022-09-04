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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
           

        }

    

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if(pictureBox10.Visible==true)
            {
                pictureBox10.Visible = false;
                pictureBox9.Visible = true;

            }
            else if (pictureBox9.Visible == true)
            {
                pictureBox9.Visible = false;
                pictureBox8.Visible = true;

            }
            else if (pictureBox8.Visible == true)
            {
                pictureBox8.Visible = false;
                pictureBox7.Visible = true;

            }
            else if (pictureBox7.Visible == true)
            {
                pictureBox7.Visible = false;
                pictureBox11.Visible = true;

            }
            else if (pictureBox11.Visible == true)
            {
                pictureBox11.Visible = false;
                pictureBox10.Visible = true;

            }
           
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.ShowDialog();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Form9 f3 = new Form9();
            f3.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;

namespace intrervention
{
    public partial class Form3 : Form
    {
        private readonly module A1 = new module();

        public Form3()
        {
            InitializeComponent();
        }
        public void Datagridintervention()
        {
            A1.qr = "Select * from Tableintervention";
            A1.searchData();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = A1.dt;
            dataGridView1.Refresh();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

            dateTimePicker2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            
            richTextBox1.Visible = true;
            button3.Visible = true;
            richTextBox2.Visible = true;
            button4.Visible = true;
            label4.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            richTextBox2.Visible = true;


        }




        private void Form3_Load(object sender, EventArgs e)
        {
            A1.qr = "select*from Tableintervention";
            A1.searchData();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = A1.dt;
            dataGridView1.Refresh();

        }
        private void clearO()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            
            comboBox3.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("sélectionner pour supprimer");
            }
            else
            {
                A1.qr = "Delete from Tableintervention where nom = '" + textBox1.Text + "'";
                A1.con = new SqlConnection(A1.stringcon);
                A1.cmd = new SqlCommand(A1.qr, A1.con);
                A1.con.Open();
                A1.I = A1.cmd.ExecuteNonQuery();
                A1.con.Close();
                if (A1.I != 0)
                {
                    MessageBox.Show("Effectue");
                   Datagridintervention();
                    clearO();
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            if (ind > -1)
            {
                DataGridViewRow selectedRows = dataGridView1.Rows[ind];
                textBox1.Text = selectedRows.Cells[0].Value.ToString();
                textBox2.Text = selectedRows.Cells[1].Value.ToString();
                textBox3.Text = selectedRows.Cells[2].Value.ToString();
                dateTimePicker1.Text = selectedRows.Cells[3].Value.ToString();
                comboBox1.Text = selectedRows.Cells[4].Value.ToString();
                textBox4.Text = selectedRows.Cells[5].Value.ToString();
                comboBox2.Text = selectedRows.Cells[6].Value.ToString();
                comboBox3.Text = selectedRows.Cells[7].Value.ToString();
            }
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                imprimer sa = new imprimer();
            CrystalReport3 CR1 = new CrystalReport3();
            CR1.SetParameterValue("nom", textBox1.Text);
            CR1.SetParameterValue("prenom", textBox2.Text);
            CR1.SetParameterValue("fonction", textBox3.Text);
            CR1.SetParameterValue("date", dateTimePicker1.Text);
            CR1.SetParameterValue("nature d'intervention", comboBox1.Text);
            CR1.SetParameterValue("autre", textBox4.Text);
            CR1.SetParameterValue("l'importance", comboBox2.Text);
            CR1.SetParameterValue("l'urgence", comboBox3.Text);
            CR1.SetParameterValue("observations", richTextBox1.Text);
            CR1.SetParameterValue("date de traitement", dateTimePicker2.Text);
            sa.imprimercrystal1.ReportSource = CR1;
            sa.Show();
        }
            else if(radioButton2.Checked==true)
            {
                imprimer sa = new imprimer();
                CrystalReport5 CR1 = new CrystalReport5();
                CR1.SetParameterValue("nom", textBox1.Text);
                CR1.SetParameterValue("prenom", textBox2.Text);
                CR1.SetParameterValue("fonction", textBox3.Text);
                CR1.SetParameterValue("date", dateTimePicker1.Text);
                CR1.SetParameterValue("nature d'intervention", comboBox1.Text);
                CR1.SetParameterValue("autre", textBox4.Text);
                CR1.SetParameterValue("l'importance", comboBox2.Text);
                CR1.SetParameterValue("l'urgence", comboBox3.Text);
                CR1.SetParameterValue("observations", richTextBox1.Text);
                CR1.SetParameterValue("date de traitement", dateTimePicker2.Text);
                sa.imprimercrystal1.ReportSource = CR1;
                sa.Show();
            }
        }

        private bool Datain2()
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Entrée les observations !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(dateTimePicker2.Text))
            {
                MessageBox.Show("Entrée la date!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (Datain2())
            {
                A1.qr = "Select * from Tableservice where observations = '" + richTextBox1.Text + "' And date = '" + dateTimePicker2.Text + "'";
                A1.searchData();
                if (A1.dt.Rows.Count > 0)
                {
                    MessageBox.Show("Deja existe");
                }
                else
                {
                    A1.qr = "Insert into Tableservice values('" + richTextBox1.Text + "' , '" + dateTimePicker2.Text + "')";
                    A1.InsertData();

                    MessageBox.Show("l'opretion a ete effectuer");






                }
            }
    }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

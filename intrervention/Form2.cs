using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace intrervention
{
    public partial class Form2 : Form
    {
        private readonly module A1 = new module();



        public Form2()
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
        private bool Datain1()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Entrée le Nom !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Entrée le prenom!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (Datain1())
            {
                A1.qr = "Select * from Tableintervention where nom = '" + textBox1.Text + "' And prenom = '" + textBox2.Text + "'";
                A1.searchData();
                if (A1.dt.Rows.Count > 0)
                {
                    MessageBox.Show("Deja existe");
                }
                else
                {
                    A1.qr = "Insert into Tableintervention values('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "', '" + dateTimePicker1.Text + "', '" + comboBox1.Text + "', '" + textBox4.Text + "', '" + comboBox2.Text + "', '" + comboBox3.Text + "') ";
                    A1.InsertData();
                    Datagridintervention();
                    MessageBox.Show("l'opretion a ete effectuer");
                    


                    


                }
            }



        }



        private void Form2_Load(object sender, EventArgs e)
        {
            Datagridintervention();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text== "Autre:")
            {
                label6.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                label6.Visible = false;
                textBox4.Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            imprimer sa = new imprimer();
            CrystalReport4 CR1 = new CrystalReport4();
            CR1.SetParameterValue("nom", textBox1.Text);
            CR1.SetParameterValue("prenom", textBox2.Text);
            CR1.SetParameterValue("fonction", textBox3.Text);
            CR1.SetParameterValue("date", dateTimePicker1.Text );
            CR1.SetParameterValue("nature d'intervention", comboBox1.Text);
            CR1.SetParameterValue("autre", textBox4.Text);
            CR1.SetParameterValue("l'importance", comboBox2.Text);
            CR1.SetParameterValue("l'urgence", comboBox3.Text);
            sa.imprimercrystal1.ReportSource = CR1;
            sa.Show();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

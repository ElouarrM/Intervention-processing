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

namespace intrervention
{
    public partial class Form8 : Form
    {
        private readonly module A1 = new module();
        public Form8()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            A1.qr = "select * from Tableintervention where date BETWEEN  '" + dateTimePicker1.Text + "' And '" + dateTimePicker2.Text + "'";
            A1.searchData();
            if (A1.dt.Rows.Count > 0)
            {
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = A1.dt;
                dataGridView1.Refresh();
            }
            else
            {
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach(DataGridViewCell cell in row.Cells)
                    {
                        cell.Value = " ";
                    }
                }
            }    
            


        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        List<int> datagrid = new List<int>();
        public Form1()
        {
            InitializeComponent();
       
         
        }
        private void draw()
        {
            DataGridViewColumnCollection s=dataGridView1.Columns;

            chart1.Series.Clear();
            
            // Add series.
            for (int i = 0; i < dataGridView1.CurrentCellAddress.Y+1; i++)
            {
               
                string fdf=dataGridView1.Rows[i].Cells[0].Value.ToString();
                Series series = this.chart1.Series.Add(i.ToString());
                series.Points.Add(Int32.Parse(fdf));
                // Add series.
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            draw();
        }
    }
}

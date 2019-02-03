using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace WindowsFormsControlLibrary1
{
    public partial class UserControl1: UserControl
    {
        string path = "";
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName.EndsWith(".accdb"))
            {
                try
                {
                path = ofd.InitialDirectory + ofd.FileName;
                string connectionPath = "Dbq="+path+";";
                string connectionString = "Driver={Microsoft Access Driver (*.mdb, *.accdb)};"+connectionPath;
                OdbcConnection conn = new OdbcConnection(connectionString);
                string myQuery = "Select home, room from homes";
                conn.Open();
                OdbcCommand command = new OdbcCommand(myQuery);

                command.Connection = new OdbcConnection(connectionString);

                OdbcDataAdapter adapter = new OdbcDataAdapter();
                adapter.SelectCommand = command;
                DataSet myDataSet = new DataSet();

                string dataTable = "tableA";
                adapter.Fill(myDataSet, dataTable);
                DataTable myDataTable = myDataSet.Tables[dataTable];
                dataFromDatabase = "";
                foreach (DataRow rd in myDataTable.Rows)
                {
                    dataFromDatabase += rd["room"] +" "+rd["home"]+'\n'; 
                }
            }catch{
                MessageBox.Show("error with read database");
            }
            }
            else
            {
                MessageBox.Show("file is not access database");
            }
        }
    }
}

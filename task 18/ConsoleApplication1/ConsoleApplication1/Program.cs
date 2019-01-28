using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=E:\\angular\\home.accdb;";
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
             foreach (DataRow rd in myDataTable.Rows)
            {
                Console.WriteLine(rd["room"]);
                Console.WriteLine(rd["home"]);

            }
Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"provider=Microsoft.ACE.OLEDB.12.0;data source=E:\angular\home.accdb";
            OleDbConnection conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand command = conn.CreateCommand();
            string selectString = "select room,home from homes";
            command.CommandText = selectString;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = command;
            DataSet myDataSet = new DataSet();
            string dataTableName = "tableA";
            adapter.Fill(myDataSet, dataTableName);
            DataTable myDataTable = myDataSet.Tables[dataTableName];
            foreach (DataRow rd in myDataTable.Rows)
            {
                Console.WriteLine(rd["room"]);
                Console.WriteLine(rd["home"]);

            }
            Console.ReadLine();
            
        }
    }
}

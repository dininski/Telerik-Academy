using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadExcelFile
{
    class ReadExcel
    {
        static void Main()
        {
            OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=..\..\file.xls;Extended Properties=""Excel 12.0 XML;HDR=Yes""");

            OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", dbConnection);

            dbConnection.Open();

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = (string)reader["Name"];
                double score = (double)reader["Score"];

                Console.WriteLine("Name: {0}, Score: {1}", name, score);
            }
        }
    }
}

namespace AddToExcelFile
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddToExcelFile
    {
        public static void Main()
        {
            OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=..\..\file.xls;Extended Properties=""Excel 12.0 XML;HDR=Yes""");

            Console.WriteLine("Please enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter score: ");
            double score = double.Parse(Console.ReadLine());
            InsertDataIntoExcel(name, score, dbConnection);

        }

        static void InsertDataIntoExcel(string name, double score, OleDbConnection connection)
        {
            OleDbCommand myCommand = new OleDbCommand("INSERT INTO [Sheet1$] (Name, Score) VALUES (@Name,@Score)", connection);
            connection.Open();
            myCommand.Parameters.AddWithValue("@Name", name);
            myCommand.Parameters.AddWithValue("@Score", score);
            myCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}

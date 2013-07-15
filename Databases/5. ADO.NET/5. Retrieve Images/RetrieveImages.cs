using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveAndSaveImages
{
    public class RetrieveImages
    {
        private static string FileExtension = ".jpg";

        static void Main()
        {
            SqlConnection dbConnection = new SqlConnection("Server=.; " +
                "Database=Northwind;Integrated Security = true");

            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryId, CategoryName, Picture FROM Categories", dbConnection);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    byte[] image;
                    int catId;
                    string catName;

                    while (reader.Read())
                    {
                        image = (byte[])reader["Picture"];
                        catId = (int)reader["CategoryId"];
                        catName = (string)reader["CategoryName"];

                        SaveFile(image, catName + catId.ToString() + FileExtension);

                        image = null;
                    }
                }
            }
        }

        private static void SaveFile(byte[] image, string fileName)
        {

            var filenameString = fileName.Replace('/', '.');

            FileStream fs = new FileStream(filenameString, FileMode.Create);

            using (fs)
            {
                fs.Write(image, 78, image.Length - 78);
            }
        }
    }
}

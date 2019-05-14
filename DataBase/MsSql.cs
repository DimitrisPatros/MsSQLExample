using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace DataBase
{
    class MsSql
    {
        public List<Item> Products;

        public MsSql()
        {
            Products = new List<Item>();
        }

        public void ReadFormDatabase()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                ContactToDatabase(conn);

                // Create the command
                SqlCommand command = new SqlCommand("SELECT [id] ,[name],[price],[category] FROM[dbo].[item]", conn);
                
                // Add the parameters.
                command.Parameters.Add(new SqlParameter("0", 1));
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0} \t | {1} \t {2} \t {3} \t  ",
                            reader[0], reader[1], reader[2], reader[3]));
                        Item temp = new Item(int.Parse(reader[0].ToString()),
                            reader[1].ToString(),
                            double.Parse(reader[2].ToString()),
                            int.Parse(reader[3].ToString()));
                        Products.Add(temp);
                    }
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }//end of connection


        public void SaveToJason()
        {
            string jsonData = JsonConvert.SerializeObject(Products, Formatting.None);
            File.WriteAllText(@"C:\Users\patro\Desktop\doc\tryToSaveToJason.json", jsonData);
        }

        public void LoadFromJason()
        {
            string data = File.ReadAllText(@"C:\Users\patro\Desktop\doc\tryToSaveToJason.json");
            var tempProducts = JsonConvert.DeserializeObject<List<Item>>(data);

            foreach (Item t in tempProducts)
            {
                Products.Add(t);
            }
        }
        public void WrightoDatabase()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                ContactToDatabase(conn);
               
                foreach (Item t in Products)
                {
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO [dbo].[item]([name],[Price],[category])VALUES(@0,@1,@2)", conn);
                    insertCommand.Parameters.Add(new SqlParameter("0", t.Name));
                    insertCommand.Parameters.Add(new SqlParameter("1", t.Price));
                    insertCommand.Parameters.Add(new SqlParameter("2", t.Category));
                    int c = insertCommand.ExecuteNonQuery();

                }
            }
        }

        public void DeleteFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //string s3 = "Server =localhost; Database =SimpleStore; Integrated Security=SSPI;Persist Security Info=False;";
                //conn.ConnectionString = s3;
                //conn.Open();
                ContactToDatabase(conn);

                foreach (Item t in Products)
                {
                    SqlCommand insertCommand = new SqlCommand("DELETE FROM [dbo].[item] WHERE [name]=@0 ", conn);
                    insertCommand.Parameters.Add(new SqlParameter("0", t.Name));
                    //insertCommand.Parameters.Add(new SqlParameter("1", t.Price));
                    //insertCommand.Parameters.Add(new SqlParameter("2", t.Category));
                    int c = insertCommand.ExecuteNonQuery();
                }
            }
        }
        public void ContactToDatabase(SqlConnection conn)
        {     
        string s3 = "Server =localhost; Database =SimpleStore; Integrated Security=SSPI;Persist Security Info=False;";
        conn.ConnectionString = s3;
                conn.Open();
        }






}

    
}


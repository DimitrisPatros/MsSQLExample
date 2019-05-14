using System;
using System.Data.SqlClient;

namespace DataBase
{
    class MsSql:ReadSaveJson
    {

        public void ReadFormDatabase()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                ConectToDatabase(conn);
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
                        Item temp = new Item(int.Parse(reader[0].ToString()),reader[1].ToString(),
                                double.Parse(reader[2].ToString()),int.Parse(reader[3].ToString()));

                        Products.Add(temp);
                    }
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }


        public void WrightoDatabase()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                ConectToDatabase(conn);

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
                ConectToDatabase(conn);

                foreach (Item t in Products)
                {
                    SqlCommand insertCommand = new SqlCommand("DELETE FROM [dbo].[item] WHERE [name]=@0 ", conn);
                    insertCommand.Parameters.Add(new SqlParameter("0", t.Name));
                    int c = insertCommand.ExecuteNonQuery();
                }
            }
        }


        public void ConectToDatabase(SqlConnection conn)
        {
            string s3 = "Server =localhost; Database =SimpleStore; Integrated Security=SSPI;Persist Security Info=False;";
            conn.ConnectionString = s3;
            conn.Open();
        }


    }
}


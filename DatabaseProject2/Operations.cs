using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DatabaseProject2
{
    public class Operations
    {
        private readonly string _connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AdventureWorks2012;Integrated Security=True;Connection Timeout = 6000";

        private readonly SqlCommand _command;
        private TimeSpan averageTime;

        public Operations(String query)
        {
            _command = new SqlCommand(query);
        }

        private TimeSpan RunQuery()
        {
            DateTime beginTime = DateTime.Now;
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                _command.Connection = connection;

                for (int i = 0; i < 100; i++)
                    _command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            DateTime endTime = DateTime.Now;
            TimeSpan elapsed = endTime - beginTime;
            Console.WriteLine(beginTime + " " + endTime);
            Console.Write("Birim ölçüm sonucu(toplam süre) : " + elapsed );
            return elapsed;
        }

        public void RunQuery100Times()
        {
            TimeSpan totalTime = TimeSpan.Zero;
            for (int i = 0; i < 100; i++)
            {
                totalTime += RunQuery();
                Console.WriteLine(" (100/" + (i + 1) + ")" + "\n");
            }

            averageTime = totalTime / 100;
            Console.WriteLine("100 ölçüm sonucu(ortalama süre) : " + averageTime + "\n");
        }

        public void WriteToFile(string fileName, string numberOfQuery)
        {
            string[] lines =
            {
                "***************************************************************",
                " ",
                "After Indexes",
                "Query"+numberOfQuery+" : Average Time is " + averageTime ,
                " ",
                "***************************************************************\n"
            };

            File.AppendAllLines(fileName, lines);
            averageTime = TimeSpan.Zero;
        }
    }
}
using System;

namespace DatabaseProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 100 Run report for each query
            string filePath = "D:\\Proje\\DatabaseProject2\\DatabaseProject2\\Document\\Output.txt";
            Operations query1 = new Operations(Queries.Query1);
            query1.RunQuery100Times();
            query1.writeToFile(filePath, "1");
            Operations query2 = new Operations(Queries.Query2);
            query2.RunQuery100Times();
            query2.writeToFile(filePath, "2");
            Operations query3 = new Operations(Queries.Query3);
            query3.RunQuery100Times();
            query3.writeToFile(filePath, "3");
        }
    }
}
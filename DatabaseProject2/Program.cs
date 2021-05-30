using System;

namespace DatabaseProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 100 Run report for each query
            Operations query1 = new Operations(Queries.Query1);
            query1.RunQuery100Times();
            
            Operations query2 = new Operations(Queries.Query2);
            query2.RunQuery100Times();
            
            Operations query3 = new Operations(Queries.Query3);
            query3.RunQuery100Times();
        }
    }
}
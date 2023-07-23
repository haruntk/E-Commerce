using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var operation = new DatabaseOperations();
            operation.BulkInsert();
        }
        public class DatabaseOperations
        {
            public void BulkInsert()
            {
                var Connection = new SqlConnection()
                {
                    ConnectionString = "Server=localhost;Database=ECommerceDb;Trusted_Connection=True;TrustServerCertificate=True"
                };
                string sql = "SELECT * FROM Categories";
                SqlCommand cmd = new SqlCommand(sql, Connection);
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                SqlBulkCopy sqlBulk = new SqlBulkCopy(Connection);
                sqlBulk.DestinationTableName = "ProductCategories";

                sqlBulk.ColumnMappings.Add("CategoryId","CategoryId");
                sqlBulk.WriteToServer(reader);
                Connection.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        public string BulkInsert(DataTable dt, string ProductCategories)
        {
            var Connection = new SqlConnection()
            {
                ConnectionString = "Server=localhost;Database=ECommerceDb;Trusted_Connection=True;TrustServerCertificate=True"
            };
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(Connection))
            {
                bulkCopy.DestinationTableName = ProductCategories;
                try
                {
                    bulkCopy.WriteToServer(dt);
                    return ("Aktarım Tamamlandı");
                }
                catch (Exception ex)
                {
                    return (ex.Message);
                }
            }
        }
    }
}

using System.Data.SqlClient;
using CustomerOrderViewer.Models;

namespace CustomerOrderViewer.Repository
{
    class   CustomerOrderDetailCommand
    {
        private string _connectionString;

        public CustomerOrderDetailCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        //Connection, Command, Reader
        public IList<CustomerOrderDetailModel> GetList()
        {
            List<CustomerOrderDetailModel> customerOrderDetailModels = new();

            //The connection will be disposed after we use the connection
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                //Cria um comando
                using(SqlCommand command = new SqlCommand(@"SELECT 
                                                                CustomerOrderId, 
                                                                CustomerId, ItemId, 
                                                                FirstName, 
                                                                LastName, 
                                                                [Description], 
                                                                Price 
                                                            From CustomerOrderDetail", connection))
                {

                    //The reader object helps us read the db output
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                          {
                            //While there are records, you read.
                            while (reader.Read())
                            {
                                CustomerOrderDetailModel customerOrderDetailModel = new()
                                {
                                    CustomerOrderId = Convert.ToInt32(reader["CustomerOrderId"]),
                                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                    ItemId = Convert.ToInt32(reader["ItemId"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"])
                                };
                                
                                customerOrderDetailModels.Add(customerOrderDetailModel);
                            }
                        }
                    }
                }
            }
            return customerOrderDetailModels;
        }
    }


}
using System.Data.SqlClient;
using CustomerOrderViewer.Models;
using CustomerOrderViewer.Repository;

namespace CustomerOrderViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CustomerOrderDetailCommand customerOrderDetailCommand = new CustomerOrderDetailCommand(@"Data Source = localhost; Initial Catalog = CustomerOrderViewer; Integrated Security = True");
            
                IList<CustomerOrderDetailModel> customerOrderDetailModels = customerOrderDetailCommand.GetList();

                if (customerOrderDetailModels.Any())
                {
                    foreach (CustomerOrderDetailModel customerOrderDetailModel in customerOrderDetailModels)
                    {
                        Console.WriteLine("{0}: Fullname {1} {2} (id: {3}) - purchased {4} for {5} (id: {6})",
                        customerOrderDetailModel.CustomerOrderId,
                        customerOrderDetailModel.FirstName,
                        customerOrderDetailModel.LastName,
                        customerOrderDetailModel.CustomerId,
                        customerOrderDetailModel.Description,
                        customerOrderDetailModel.Price,
                        customerOrderDetailModel.ItemId
                        );

                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error: {0}", ex.Message);
            }

        }
    }
}
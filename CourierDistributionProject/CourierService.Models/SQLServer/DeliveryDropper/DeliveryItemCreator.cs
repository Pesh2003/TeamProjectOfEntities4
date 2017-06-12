using CourierService.DbContext.SQLServer;
using CourierService.DbContextModels.SQLServer;
using CourierService.Models.SQLServer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Models.SQLServer
{
    public class DeliveryItemCreator : IDeliveryItemCreator
    {
        private IQueriesDeliveryItem QueriesDeliveryItem;
        private ICorierServiceContext dbContext;
        private int userId;

        public DeliveryItemCreator(ICorierServiceContext dbContext, IQueriesDeliveryItem QueriesDeliveryItem, int userId)
        {
            this.QueriesDeliveryItem = QueriesDeliveryItem;
            this.dbContext = dbContext;
            this.userId = userId;
        }

        public void declareItem()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            bool isFormFilledCorrect = true;
            do
            {
                Console.WriteLine(" Choose an office nearby to drop item");
                Console.WriteLine("-----------------------------------------------");

                var officeDetails = QueriesDeliveryItem.AddOfficeToForm(dbContext);
                if (officeDetails == null)
                {
                    return;
                }

                Console.WriteLine(" Add Details about your delivery package:\n  (Laptop, Set of Glasses, Lamp ... ext.)");
                var detailsFreight = Console.ReadLine();
                Console.WriteLine("-----------------------------------------------");

                Console.WriteLine(" Choose destination City");

                var destinationCity = QueriesDeliveryItem.AddCityToForm(dbContext);

                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(" Choose service options:");
                Console.WriteLine("-----------------------");

                var addOptionsToForm = QueriesDeliveryItem.AddOptionsToForm(dbContext);

                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("| Your order:  is that correct -->  Y / N     |");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("| Office to drop to --> град {0}, адрес: {1}", officeDetails[1], officeDetails[2]);
                Console.WriteLine("| DeTails           --> {0}", detailsFreight);
                Console.WriteLine("| Destination city  --> {0}", destinationCity[1]);
                Console.WriteLine("| ServicesType | Weight |  Price |  TimeDuration ");
                Console.WriteLine("| {0}      | {1}     |  {2} |  {3}", addOptionsToForm.ServiceType, addOptionsToForm.Weight,
                    addOptionsToForm.Price, addOptionsToForm.TimeDuration);

                if (Console.ReadLine().ToLower() == "y")
                {
                    var serv = new Service()
                    {
                        CreateDate = DateTime.Now,
                        City = dbContext.Cities.Find(int.Parse(destinationCity[0])),
                        Details = detailsFreight,
                        ServiceOption = dbContext.ServiceOptions.Find(addOptionsToForm.ServOptionId),
                        OfficeId = int.Parse(officeDetails[0]),
                        IsTaken = false,
                        IsCompleted = false,
                        UserId = userId
                    };

                    dbContext.Services.Add(serv);
                    dbContext.SaveChanges();
                    Console.WriteLine(" Your order is processed");
                    Console.WriteLine();
                    isFormFilledCorrect = false;
                }
                else
                {
                    Console.WriteLine(" If you what to exit this service type \" EXIT \" \n to refill form \"ENTER\" ");
                    if (Console.ReadLine().ToLower() == "exit")
                    {
                        break;
                    }
                }

            } while (isFormFilledCorrect);

        }
    }
}

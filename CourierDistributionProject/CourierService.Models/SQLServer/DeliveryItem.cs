using CourierService.DbContext.SQLServer;
using CourierService.Models.SQLServer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Models.SQLServer
{
    public class DeliveryItem : IDeliveryItem
    {
        private IFormAdder formadder;
        private ICorierServiceContext dbContext;

        public DeliveryItem(ICorierServiceContext dbContext, IFormAdder formAdder)
        {
            this.formadder = formAdder;
            this.dbContext = dbContext;
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

                var officeDetails = formadder.AddOfficeToForm(dbContext);

                Console.WriteLine(" Add Details about your delivery package:\n  (Laptop, Set of Glasses, Lamp ... ext.)");
                var detailsFreight = Console.ReadLine();
                Console.WriteLine("-----------------------------------------------");

                Console.WriteLine(" Choose destination City");
                var destinationCity = Console.ReadLine();
                Console.WriteLine("-----------------------------------------------");

                Console.WriteLine("Choose service options:");

                var addOptionsToForm = formadder.AddOptionsToForm(dbContext);

                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("| Your order:  is that correct -->  Y / N     |");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("| Office to drop to --> град {0}, адрес:{1}", officeDetails[0], officeDetails[1]);
                Console.WriteLine("| DeTails           --> {0}", detailsFreight);
                Console.WriteLine("| Destination city  --> {0}", destinationCity);
                Console.WriteLine("| ServicesType | Weight |  Price |  TimeDuration ");
                Console.WriteLine("| {0}      | {1}     |  {2} |  {3}", addOptionsToForm.ServiceType, addOptionsToForm.Weight,
                    addOptionsToForm.Price, addOptionsToForm.TimeDuration);

                if (Console.ReadLine() == "Y")
                {
                    // write to database TODO
                    isFormFilledCorrect = false;
                }
                else
                {
                    Console.WriteLine("If you what to exit this service type \" EXIT \" \n to refill form \"ENTER\" ");
                    if (Console.ReadLine().ToLower() == "exit")
                    {
                        break;
                    }
                }
            } while (isFormFilledCorrect);

        }
    }
}

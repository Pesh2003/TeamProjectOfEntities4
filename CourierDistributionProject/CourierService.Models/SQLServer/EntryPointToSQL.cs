using CourierService.DbContext.SQLServer;
using CourierService.Models.SQLServer.Contracts;
using CourierService.Models.SQLServer.DistributionFixer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationModels.Model.Input;
using ApplicationModels.Model.Output;

namespace CourierService.Models.SQLServer
{
    public class EntryPointToSQL
    {
        private readonly ICommandParser comandParser;
        private readonly ICorierServiceContext dbContext;

        public EntryPointToSQL(ICorierServiceContext dbContext, ICommandParser comandParser)
        {
            this.comandParser = comandParser;
            this.dbContext = dbContext;
        }

        public int Header()
        {
            ConsoleOutput.PrintLine("*****************************************");
            ConsoleOutput.PrintLine("   Choose service");
            ConsoleOutput.PrintLine("-----------------------------------------");
            ConsoleOutput.PrintLine(" 1 Declare an item for delivery");
            ConsoleOutput.PrintLine(" 2 Get / Release an Item of distribution (Fixer)");

            var parsedCommand = comandParser.CommandParse("Service");

            if (parsedCommand == 0)
            {
                return parsedCommand;
            }
            return parsedCommand;
        }

        public void AssignItams(int userId)
        {
            IQueriesDeliveryItem queriesDeliveryItem = new QueriesDeliveryItem(comandParser);

            Console.WriteLine("Do you what to see all your created deliveries -->  Y / N ");
            if (ConsoleInput.ReadLine().ToLower() == "y")
            {
                queriesDeliveryItem.QueryAllServicesOfGivenUser(dbContext, userId);
                if (ConsoleInput.ReadLine().ToLower() == "exit")
                {
                    return;
                }
            }
            var n = new DeliveryItemCreator(dbContext, queriesDeliveryItem, userId);
            n.declareItem();
        }

        public void CommitDistribution(int userId)
        {
            IQueriesFixer distributions = new QueriesFixer();
            IDistributionPicker distributionPicker = new DistributionPicker();
            IDistributionReleaser distributionReleaser = new DistributionReleaser();

            Console.WriteLine(" 1 Select available items for distribution \n 2 Close distribution");

            var resParse = comandParser.CommandParse("Distribution");
            if (resParse == 0)
            {
                return;
            }

            if (resParse == 1)
            {
                distributionPicker.PickUpDistribution(dbContext, distributions, comandParser, userId);
            }
            else
            {
                distributionReleaser.CloseDistribution(dbContext, distributions, comandParser, userId);
            }
        }
    }
}

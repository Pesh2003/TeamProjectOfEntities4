using ApplicationModels.Constant;
using ApplicationModels.Model.Input;
using ApplicationModels.Model.Output;
using ApplicationModels.Model.SQLServerConnection;

namespace ApplicationModels.Model
{
    public class ApplicationTest
    {
        public void Run()
        {
            while (true)
            {
                ConstantInformation.PrintAvailableKeyCodes();
                var keyCommand = ConsoleInput.ReadLine();
                switch (keyCommand)
                {
                    case "1":
                        {
                            ApplicationModel.PrintUsersInformation();
                        }
                        break;
                    case "2":
                        { 
                            ConsoleOutput.PrintLine(Constant.Constant.EXIT_SUCCESSFUL);
                        }
                        return;
                    default:
                        {
                            ConsoleOutput.PrintLine(Constant.Constant.WRONG_SYMBOL);
                        }
                        break;
                }
            }
        }
    }
}

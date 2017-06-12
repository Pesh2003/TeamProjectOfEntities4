using System.Collections.Generic;

namespace CourierService.Models.Postgre.Login.Contracts
{
   public interface ILoginInformation
   {
       IList<string> GetLoginInformation();
   }
}

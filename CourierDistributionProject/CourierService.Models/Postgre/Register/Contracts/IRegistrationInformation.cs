﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Models.Postgre.Register
{
   public interface IRegistrationInformation
   {
       IList<string> GetRegistrationInformation();
   }
}

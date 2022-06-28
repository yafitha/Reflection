using Logics.Bl;
using Logics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Services
{
    public class DataService : IDataService
    {
        public bool IsPrimeNumber(string number)
        {
             return NumberManipulationBL.IsPrimeNumber(number);
        }
    }
}

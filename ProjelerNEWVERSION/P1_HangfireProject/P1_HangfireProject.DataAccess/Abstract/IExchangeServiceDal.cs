using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_HangfireProject.Core.Entities.Models;

namespace P1_HangfireProject.DataAccess.Abstract
{
    public interface IExchangeServiceDal
    {
        ExchangeRate? GetExchangeRateDal(int id);

        Rates? GetRatesDal(int id);

        void SaveChangesDal(int exchangeRatesId, int ratesId, decimal newTry, DateTime newDate);
    }
}

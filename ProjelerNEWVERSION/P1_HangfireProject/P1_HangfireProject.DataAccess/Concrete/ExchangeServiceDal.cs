using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_HangfireProject.Core.Entities.Models;
using P1_HangfireProject.DataAccess.Abstract;
using P1_HangfireProject.Core.Contexts.Data;

namespace P1_HangfireProject.DataAccess.Concrete
{
    public class ExchangeServiceDal : IExchangeServiceDal
    {
        ProjectDbContext _context;

        public ExchangeServiceDal(ProjectDbContext context)
        {

            _context = context;

        }

        public ExchangeRate? GetExchangeRateDal(int id)
        {
            return _context.ExchangeRates.Where(x => x.ExchangeRateId == id).SingleOrDefault();
        }

        public Rates? GetRatesDal(int id)
        {
            return _context.Rates.Where(x => x.RatesId == id).SingleOrDefault();
        }

        public void SaveChangesDal(int exchangeRatesId, int ratesId, decimal newTry, DateTime newDate)
        {
            var dataExchangeRate = GetExchangeRateDal(exchangeRatesId);
            var dataRate = GetRatesDal(ratesId);


            dataExchangeRate.Date = newDate;
            dataRate.TRY = newTry;

            _context.SaveChanges();
        }
    }
}

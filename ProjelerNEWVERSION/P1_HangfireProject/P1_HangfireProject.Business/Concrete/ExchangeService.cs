using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_HangfireProject.Business.Abstract;
using P1_HangfireProject.Core.Entities.Models;
using P1_HangfireProject.DataAccess.Abstract;

namespace P1_HangfireProject.Business.Concrete
{
    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeServiceDal _exchangeServiceDal;

        public ExchangeService(IExchangeServiceDal exchangeServiceDal)
        {

            _exchangeServiceDal = exchangeServiceDal;
        }

        public ExchangeRate GetExchangeRate(int id)
        {
            return _exchangeServiceDal.GetExchangeRateDal(id);
        }

        public Rates GetRates(int id)
        {
            return _exchangeServiceDal.GetRatesDal(id) ?? null;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_HangfireProject.Business.Abstract;
using P1_HangfireProject.DataAccess.Abstract;
using P1_HangfireProject.Hangfires.Abstract;

namespace P1_HangfireProject.Hangfires
{
    public class HandleHangfire
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerServiceDal _customerServiceDal;
        private readonly IHangfireInfo _hangfireInfo;

        public HandleHangfire(ICustomerService customerService, ICustomerServiceDal customerServiceDal, IHangfireInfo hangfireInfo)
        {
            _customerService = customerService;
            _customerServiceDal = customerServiceDal;
            _hangfireInfo = hangfireInfo;
        }

        public void MyHangfireFunction()        
        {
            _hangfireInfo.HangfireStartText();

            // Get Customers With Balanace!=1000.00M
            var data = _customerService.GetCustomersWithNonStandardBalance();

            /* 
             * Check if data null, if null write 'No member(s) were effected.'
             * Then exit hangfire.
             */
            if (data == null)
            {
                _hangfireInfo.HangfireNoChangeText();
                _hangfireInfo.HangfireEndText();
                return;
            }

            // Update balances to 1000.00M
            _customerServiceDal.UpdateCustomerBalance(data);

            _hangfireInfo.HangfireEndText();
        }
    }
}

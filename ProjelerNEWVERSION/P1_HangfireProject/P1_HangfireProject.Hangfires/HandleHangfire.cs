using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using P1_HangfireProject.Business.Abstract;
using P1_HangfireProject.Core.Entities.Models;
using P1_HangfireProject.DataAccess.Abstract;
using P1_HangfireProject.Hangfires.Abstract;

namespace P1_HangfireProject.Hangfires
{
    public class HandleHangfire
    {
        private readonly IHangfireInfo _hangfireInfo;
        private readonly IExchangeService _exchangeService;
        private readonly IExchangeServiceDal _exchangeServiceDal;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;
        private readonly IBulkService _bulkService;

        private const int usdToTryId = 3;
        private const int ratesId = 1;

        public HandleHangfire(IHangfireInfo hangfireInfo, 
            IExchangeService exchangeService, 
            IHttpClientFactory httpClientFactory, 
            IExchangeServiceDal exchangeServiceDal,
            IProductService productService,
            IBulkService bulkService)
        {
            _hangfireInfo = hangfireInfo;
            _exchangeService = exchangeService;
            _exchangeServiceDal = exchangeServiceDal;
            _httpClientFactory = httpClientFactory;
            _productService = productService;
            _bulkService = bulkService;
        }

        public void RefreshProductPrices()        
        {
            using var client = _httpClientFactory.CreateClient();
            var accessKey = "d5e4066f5df296807839be889651e547";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://api.exchangeratesapi.io/v1/latest?access_key={accessKey}&symbols=TRY")
            };

            using (var response = client.Send(request))
            {
                response.EnsureSuccessStatusCode();

                var body = response.Content.ReadAsStringAsync().Result;
                ExchangeRate? results = JsonSerializer.Deserialize<ExchangeRate>(body);

                _exchangeServiceDal.SaveChangesDal(usdToTryId, ratesId, results.Rates.TRY, results.Date);

                _productService.SaveChanges(results.Rates.TRY, _productService.GetAllProducts());
            }
        }

        public void Test()
        {
            _bulkService.BulkOperations();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SampleTask.Vending.DomainModel.Models;
using SampleTask.Vending.Service.Contract;

namespace SampleTask.Vending.Service.Implementation
{
    public class StoreService : IStoreService
    {
        private readonly ILogger _logger;

        public StoreService(ILogger logger)
        {
            _logger = logger;
        }

        public void GetAllStorePrices(StoreModel currentStore)
        {
            foreach (var item in currentStore.Items)
            {
                _logger.WriteLog($"{item.Name} = {item.Price}");
            }
        }

        public void GetStoreMenu(StoreModel currentStore)
        {
            _logger.WriteLog("\n\nAvailable commands:");
            _logger.WriteLog("prices                                   - Show prices of items");
            _logger.WriteLog("insert (money)                           - Money put into money slot");
            _logger.WriteLog("order (coke, fanta, chips, snickers)     - Order from machines buttons");
            _logger.WriteLog("app order (coke, fanta, chips, snickers) - Order+pay in mobile app");
            _logger.WriteLog("recall                                   - Gives money back");
            _logger.WriteLog("refill                                   - Refills the stock");
            _logger.WriteLog("-------");
            _logger.WriteLog("Inserted money: " + currentStore.Budget);
            _logger.WriteLog("-------\n\n");
        }
    }
}

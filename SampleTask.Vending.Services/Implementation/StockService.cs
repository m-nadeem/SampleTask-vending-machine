using System;
using System.Collections.Generic;
using System.Text;
using SampleTask.Vending.DomainModel.Models;
using SampleTask.Vending.DomainModel.Utils;
using SampleTask.Vending.Service.Contract;

namespace SampleTask.Vending.Service.Implementation
{
    class StockService : IStockService
    {
        private readonly ILogger _logger;

        public StockService(ILogger logger)
        {
            _logger = logger;
        }

        public StoreModel RefillStock(StoreModel currentStore, IEnumerable<ItemModel> initialStock)
        {
            _logger.WriteLog("Refilling all stock items.");
            currentStore.Items = initialStock.Clone();
            return currentStore;
        }
    }
}

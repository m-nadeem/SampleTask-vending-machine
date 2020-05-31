using System.Linq;
using SampleTask.Vending.DomainModel.Enums;
using SampleTask.Vending.DomainModel.Models;
using SampleTask.Vending.DomainModel.Utils;
using SampleTask.Vending.Service.Contract;

namespace SampleTask.Vending.Service.Implementation
{
    public class OrderFromAppService : IOrderService
    {
        private readonly ILogger _logger;

        public OrderFromAppService(ILogger logger)
        {
            _logger = logger;
        }

        public StoreModel OrderItem(string itemToOrder, StoreModel currentStore)
        {
            ItemsEnum itemToOrderEnum;

            try
            {
                itemToOrderEnum = itemToOrder.ToItemsEnum();
            }
            catch
            {
                _logger.WriteLog($"The item {itemToOrder} is not in stock.");
                return currentStore;
            }

            var item = currentStore.Items.FirstOrDefault(x => x.Name == itemToOrderEnum);

            if (item == null)
            {
                _logger.WriteLog($"The item {itemToOrder} is not in stock.");
                return currentStore;
            }

            if (item.Stock == 0)
            {
                _logger.WriteLog($"No {itemToOrder} left.");

            }
            else
            {
                _logger.WriteLog($"Giving {itemToOrder} out.");
                item.Stock--;
            }
            return currentStore;
        }
    }
}

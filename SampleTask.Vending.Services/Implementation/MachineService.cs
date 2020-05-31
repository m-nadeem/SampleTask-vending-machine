using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleTask.Vending.DomainModel.Models;
using SampleTask.Vending.DomainModel.Utils;
using SampleTask.Vending.Service.Contract;

namespace SampleTask.Vending.Service.Implementation
{
    public class MachineService
    {
        private readonly IStoreService _storeService;
        private readonly IStockService _stockService;
        private readonly IMachineInputService _machineInputService;
        private readonly BudgetService _budgetService;
        private readonly IOrderService _orderFromAppService;
        private readonly IOrderService _orderFromMachine;
        private readonly ILogger _logger;

        public MachineService(ILogger logger)
        {
            _storeService = new StoreService(logger);
            _stockService = new StockService(logger);
            _budgetService = new BudgetService(logger);
            _orderFromAppService = new OrderFromAppService(logger);
            _orderFromMachine = new OrderFromMachineService(logger);
            _machineInputService = new MachineConsoleInputService();
            _logger = logger;
        }

        public void MachineCycle(StoreModel currentStore)
        {
            var initialStock = currentStore.Items.Clone();

            while (true)
            {
                _storeService.GetStoreMenu(currentStore);
                var userInput = _machineInputService.GetUserInput();
                if (userInput.StartsWith("insert"))
                {
                    _budgetService.AddMoney(decimal.Parse(userInput.Split(' ')[1]), currentStore);
                }
                else if (userInput.StartsWith("order"))
                {
                    _orderFromMachine.OrderItem(userInput.Split(' ')[1], currentStore);
                }
                else if (userInput.StartsWith("app order"))
                {
                    _orderFromAppService.OrderItem(userInput.Split(' ')[2], currentStore);
                }
                else if (userInput.Equals("recall"))
                {
                    _budgetService.WithdrawAllMoney(currentStore);
                }
                else if (userInput.Equals("prices"))
                {
                    _storeService.GetAllStorePrices(currentStore);
                }
                else if (userInput.Equals("refill"))
                {
                    _stockService.RefillStock(currentStore, initialStock);
                }
                else
                {
                    _logger.WriteLog("Please insert a valid command");
                }
            }   
        }
    }
}

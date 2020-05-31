using System.Collections.Generic;
using System.Linq;
using SampleTask.Vending.DomainModel.Enums;
using SampleTask.Vending.DomainModel.Models;
using SampleTask.Vending.Service.Contract;
using SampleTask.Vending.Service.Implementation;
using NUnit.Framework;

namespace SampleTask.Vending.Tests.Services
{
    public class OrderServiceTest
    {
        private IOrderService _orderFromAppService;
        private IOrderService _orderFromMachineService;
        private StoreModel _currentStore;

        [SetUp]
        public void Setup()
        {
            var logger = new ConsoleLogger();
            _orderFromAppService = new OrderFromAppService(logger);
            _orderFromMachineService = new OrderFromMachineService(logger);

            _currentStore = new StoreModel();
            _currentStore.Items = new List<ItemModel>{new ItemModel{Name = ItemsEnum.Coke, Stock = 5, Price = 20}
                , new ItemModel { Name = ItemsEnum.Fanta, Stock = 3, Price = 15 }
                , new ItemModel { Name = ItemsEnum.Chips, Stock = 4, Price = 15 }
                , new ItemModel { Name = ItemsEnum.Snickers, Stock = 5, Price = 10 }
            };
        }

        [Test]
        public void OrderFromMachineService_OrderItem_InvalidInputItem_BudgetUnchanged()
        {
            var budgetBeforeOrder = 20;
            _currentStore.Budget = budgetBeforeOrder;

            _orderFromMachineService.OrderItem("coke1", _currentStore);

            Assert.AreEqual(budgetBeforeOrder, _currentStore.Budget);
        }

        [Test]
        public void OrderFromMachineService_OrderItem_ValidInputItem_BudgetChanged()
        {
            _currentStore.Budget = 20;

            _orderFromMachineService.OrderItem("coke", _currentStore);

            Assert.AreEqual(0, _currentStore.Budget);
        }

        [Test]
        public void OrderFromMachineService_OrderItem_ValidInputItem_StockChanged()
        {
            _currentStore.Budget = 20;
            var stockBeforeOrder = _currentStore.Items.FirstOrDefault(x => x.Name == ItemsEnum.Coke)?.Stock;

            _orderFromMachineService.OrderItem("coke", _currentStore);

            Assert.AreEqual(stockBeforeOrder - 1, _currentStore.Items.FirstOrDefault(x => x.Name == ItemsEnum.Coke)?.Stock);
        }

        [Test]
        public void OrderFromMachineService_OrderItem_InvalidInputItem_StockUnchanged()
        {
            _currentStore.Budget = 20;
            var stockBeforeOrder = _currentStore.Items.FirstOrDefault(x => x.Name == ItemsEnum.Coke)?.Stock;

            _orderFromMachineService.OrderItem("coke1", _currentStore);

            Assert.AreEqual(stockBeforeOrder, _currentStore.Items.FirstOrDefault(x => x.Name == ItemsEnum.Coke)?.Stock);
        }

        [Test]
        public void OrderFromAppService_OrderItem_InvalidInputItem_BudgetUnchanged()
        {
            var budgetBeforeOrder = 20;
            _currentStore.Budget = budgetBeforeOrder;

            _orderFromAppService.OrderItem("coke1", _currentStore);

            Assert.AreEqual(budgetBeforeOrder, _currentStore.Budget);
        }

        [Test]
        public void OrderFromAppService_OrderItem_ValidInputItem_BudgetUnchanged()
        {
            var budgetBeforeOrder = 20;
            _currentStore.Budget = budgetBeforeOrder;

            _orderFromAppService.OrderItem("coke", _currentStore);

            Assert.AreEqual(budgetBeforeOrder, _currentStore.Budget);
        }

        [Test]
        public void OrderFromAppService_OrderItem_ValidInputItem_StockChanged()
        {
            _currentStore.Budget = 20;
            var stockBeforeOrder = _currentStore.Items.FirstOrDefault(x => x.Name == ItemsEnum.Coke)?.Stock;

            _orderFromAppService.OrderItem("coke", _currentStore);

            Assert.AreEqual(stockBeforeOrder - 1, _currentStore.Items.FirstOrDefault(x => x.Name == ItemsEnum.Coke)?.Stock);
        }

        [Test]
        public void OrderFromAppService_OrderItem_InvalidInputItem_StockUnchanged()
        {
            _currentStore.Budget = 20;
            var stockBeforeOrder = _currentStore.Items.FirstOrDefault(x => x.Name == ItemsEnum.Coke)?.Stock;

            _orderFromAppService.OrderItem("coke1", _currentStore);

            Assert.AreEqual(stockBeforeOrder, _currentStore.Items.FirstOrDefault(x => x.Name == ItemsEnum.Coke)?.Stock);
        }
    }
}

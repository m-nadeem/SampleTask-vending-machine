using SampleTask.Vending.DomainModel.Enums;
using SampleTask.Vending.DomainModel.Models;
using SampleTask.Vending.Service.Implementation;
using System.Collections.Generic;

namespace SampleTask.Vending
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentStore = new StoreModel();
            currentStore.Items = new List<ItemModel>{new ItemModel{Name = ItemsEnum.Coke, Stock = 5, Price = 20}
                , new ItemModel { Name = ItemsEnum.Fanta, Stock = 3, Price = 15 }
                , new ItemModel { Name = ItemsEnum.Chips, Stock = 4, Price = 15 }
                , new ItemModel { Name = ItemsEnum.Snickers, Stock = 5, Price = 10 }
            };
            var machine = new MachineService(new ConsoleLogger());
            machine.MachineCycle(currentStore);
        }
    }
}

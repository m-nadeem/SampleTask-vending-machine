using System;
using System.Collections.Generic;
using System.Text;
using SampleTask.Vending.DomainModel.Enums;
using SampleTask.Vending.DomainModel.Models;

namespace SampleTask.Vending.DomainModel.Utils
{
    public static class ItemExtensions
    {
        public static ItemsEnum ToItemsEnum(this string item)
        {
            switch (item?.ToLower())
            {
                case "coke":
                    return ItemsEnum.Coke;
                case "chips":
                    return ItemsEnum.Chips;
                case "fanta":
                    return ItemsEnum.Fanta;
                case "snickers":
                    return ItemsEnum.Snickers;
                default:
                    throw new Exception($"Item {item} not found.");
                
            }
        }

        public static IEnumerable<ItemModel> Clone(this IEnumerable<ItemModel> stocklist)
        {
            var initialStock = new List<ItemModel>();
            foreach (var item in stocklist)
            {
                initialStock.Add(new ItemModel { Name = item.Name, Stock = item.Stock, Price = item.Price });
            }

            return initialStock;
        }
    }
}

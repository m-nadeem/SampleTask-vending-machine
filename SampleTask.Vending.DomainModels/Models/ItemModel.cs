using System;
using SampleTask.Vending.DomainModel.Enums;

namespace SampleTask.Vending.DomainModel.Models
{
    public class ItemModel
    {
        public ItemsEnum Name { get; set; }
        public int Stock { get; set; }
        public Decimal Price { get; set; }
    }
}

using System.Collections.Generic;

namespace SampleTask.Vending.DomainModel.Models
{
    public class StoreModel
    {
        public IEnumerable<ItemModel> Items { get; set; }

        public decimal Budget { get; set; }

    }
}

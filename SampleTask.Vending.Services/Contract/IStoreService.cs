using System;
using System.Collections.Generic;
using System.Text;
using SampleTask.Vending.DomainModel.Models;

namespace SampleTask.Vending.Service.Contract
{
    public interface IStoreService
    {
        void GetAllStorePrices(StoreModel currentStore);

        void GetStoreMenu(StoreModel currentStore);
    }
}

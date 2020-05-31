using System;
using System.Collections.Generic;
using System.Text;
using SampleTask.Vending.DomainModel;
using SampleTask.Vending.DomainModel.Enums;
using SampleTask.Vending.DomainModel.Models;

namespace SampleTask.Vending.Service.Contract
{
    public interface IOrderService
    {
        StoreModel OrderItem(string itemToOrder, StoreModel currentStore);
    }
}

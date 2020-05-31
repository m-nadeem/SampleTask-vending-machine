using SampleTask.Vending.DomainModel.Models;

namespace SampleTask.Vending.Service.Contract
{
    public interface IBudgetAddService
    {
        StoreModel AddMoney(decimal depositAmount, StoreModel currentStore);
    }
}

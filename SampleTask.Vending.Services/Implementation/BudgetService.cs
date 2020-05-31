using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SampleTask.Vending.DomainModel.Models;
using SampleTask.Vending.Service.Contract;

namespace SampleTask.Vending.Service.Implementation
{
    public class BudgetService : IBudgetAddService, IBudgetWithrdrawService
    {
        private readonly ILogger _logger;

        public BudgetService(ILogger logger)
        {
            _logger = logger;
        }

        public StoreModel AddMoney(decimal amountToDeposit, StoreModel currentStore)
        {
            if (currentStore == null)
                throw new NoNullAllowedException("The store must be filled up with values");
            currentStore.Budget += amountToDeposit;
            _logger.WriteLog("Adding " + amountToDeposit + " to credit");
            return currentStore;
        }

        public StoreModel WithdrawAllMoney(StoreModel currentStore)
        {
            if (currentStore == null)
                throw new NoNullAllowedException("The store must be filled up with values");

            _logger.WriteLog("Returning " + currentStore.Budget + " to customer");

            currentStore.Budget = 0;

            return currentStore;
        }
    }
}

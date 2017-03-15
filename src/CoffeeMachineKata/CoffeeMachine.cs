using System;
using System.Collections.Generic;
using System.Globalization;

namespace CoffeeMachineKata
{
    internal class Cashier
    {
        private readonly Dictionary<BeverageType, decimal> _priceList;

        internal Cashier()
        {
            _priceList = new Dictionary<BeverageType, decimal>
            {
                {BeverageType.Tea, 0.4m},
                {BeverageType.Coffee, 0.6m},
                {BeverageType.Chocolate, 0.5m}
            };
        }

        internal void Checkout(BeverageRequest beverageRequest, Action onCheckoutDone, Action<decimal> onCheckoutBlocked)
        {
            if (beverageRequest.Money >= _priceList[beverageRequest.Type])
                onCheckoutDone();
            else
                onCheckoutBlocked(_priceList[beverageRequest.Type] - beverageRequest.Money);
        }
    }

    public class CoffeeMachine
    {
        private readonly IDrinkMakerMachine _drinkMakerMachine;
        private readonly Cashier _cashier;

        public CoffeeMachine(IDrinkMakerMachine drinkMakerMachine)
        {
            _drinkMakerMachine = drinkMakerMachine;
            _cashier = new Cashier();
        }

        public void Dispense(BeverageRequest beverageRequest)
        {
            _cashier.Checkout(beverageRequest, () => MakeBeverage(beverageRequest), ShowMissingMoney);
        }

        private void MakeBeverage(BeverageRequest beverageRequest)
        {
            var beverageInstruction = new DrinkMakerBeverageInstruction(beverageRequest.Type, beverageRequest.SugarAmount);
            _drinkMakerMachine.SendInstruction(beverageInstruction.ToString());
        }

        private void ShowMissingMoney(decimal money)
        {
            var message = money.ToString(CultureInfo.InvariantCulture);
            var messageInstruction = new DrinkMakerMessageInstruction(message).ToString();
            _drinkMakerMachine.SendInstruction(messageInstruction);
        }
    }
}
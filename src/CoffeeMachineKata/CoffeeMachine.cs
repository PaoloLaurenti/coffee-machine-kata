using System.Collections.Generic;
using System.Globalization;

namespace CoffeeMachineKata
{
    public class CoffeeMachine
    {
        private readonly Dictionary<BeverageType, decimal> _priceList;
        private readonly IDrinkMakerMachine _drinkMakerMachine;

        public CoffeeMachine(IDrinkMakerMachine drinkMakerMachine)
        {
            _drinkMakerMachine = drinkMakerMachine;
            _priceList = new Dictionary<BeverageType, decimal>
            {
                {BeverageType.Tea, 0.4m},
                {BeverageType.Coffee, 0.6m},
                {BeverageType.Chocolate, 0.5m}
            };
        }

        public void Dispense(BeverageRequest beverageRequest)
        {
            if (beverageRequest.Money < _priceList[beverageRequest.Type])
            {
                ShowMissingMoney(beverageRequest);
                return;
            }

            MakeBeverage(beverageRequest);
        }

        private void MakeBeverage(BeverageRequest beverageRequest)
        {
            var beverageInstruction = new DrinkMakerBeverageInstruction(beverageRequest.Type, beverageRequest.SugarAmount);
            _drinkMakerMachine.SendInstruction(beverageInstruction.ToString());
        }

        private void ShowMissingMoney(BeverageRequest beverageRequest)
        {
            var missingMoney = _priceList[beverageRequest.Type] - beverageRequest.Money;
            var message = missingMoney.ToString(CultureInfo.InvariantCulture);
            var messageInstruction = new DrinkMakerMessageInstruction(message).ToString();
            _drinkMakerMachine.SendInstruction(messageInstruction);
        }
    }
}
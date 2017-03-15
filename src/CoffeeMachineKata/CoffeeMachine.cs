using System.Collections.Generic;

namespace CoffeeMachineKata
{
    public class CoffeeMachine
    {
        private readonly IDrinkMaker _drinkMaker;
        private readonly Dictionary<BeverageType, decimal> _priceList;

        public CoffeeMachine(IDrinkMaker drinkMaker)
        {
            _drinkMaker = drinkMaker;
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
                _drinkMaker.Make($"M:{_priceList[beverageRequest.Type] - beverageRequest.Money}");
                return;
            }

            var drinkMakerInstruction = new DrinkMakerInstruction(beverageRequest.Type, beverageRequest.SugarAmount);
            _drinkMaker.Make(drinkMakerInstruction.ToString());
        }
    }
}
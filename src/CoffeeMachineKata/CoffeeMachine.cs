using System;
using System.Linq;

namespace CoffeeMachineKata
{
    public class CoffeeMachine
    {
        private readonly IDrinkMaker _drinkMaker;

        public CoffeeMachine(IDrinkMaker drinkMaker)
        {
            _drinkMaker = drinkMaker;
        }

        public void Dispense(BeverageRequest beverageRequest)
        {
            var drinkMakerInstruction = new DrinkMakerInstruction(beverageRequest.Type, beverageRequest.SugarAmount);
            _drinkMaker.Make(drinkMakerInstruction.ToString());
        }
    }
}
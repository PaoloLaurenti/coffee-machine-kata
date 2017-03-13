using System.Collections.Generic;

namespace CoffeeMachineKata
{
    public class CoffeeMachine
    {
        private readonly IDrinkMaker _drinkMaker;
        private readonly Dictionary<BeverageType, string> _drinkMakerCommands;

        public CoffeeMachine(IDrinkMaker drinkMaker)
        {
            _drinkMaker = drinkMaker;
            _drinkMakerCommands = new Dictionary<BeverageType, string>
            {
                {BeverageType.Tea, "T::" },
                {BeverageType.Coffee, "C::" },
            };
        }

        public void Dispense(Beverage beverage)
        {
            _drinkMaker.Make(_drinkMakerCommands[beverage.Type]);
        }
    }
}
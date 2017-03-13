using System.Collections.Generic;

namespace CoffeeMachineKata
{
    public class CoffeeMachine
    {
        private readonly IDrinkMaker _drinkMaker;
        private readonly Dictionary<BeverageType, DrinkMakerInstruction> _drinkMakerInstructions;

        public CoffeeMachine(IDrinkMaker drinkMaker)
        {
            _drinkMaker = drinkMaker;
            _drinkMakerInstructions = new Dictionary<BeverageType, DrinkMakerInstruction>
            {
                {BeverageType.Tea, new DrinkMakerInstruction("T")},
                {BeverageType.Coffee, new DrinkMakerInstruction("C")},
                {BeverageType.Chocolate, new DrinkMakerInstruction("H")}
            };
        }

        public void Dispense(Beverage beverage)
        {
            var drinkMakerInstruction = _drinkMakerInstructions[beverage.Type];
            _drinkMaker.Make(drinkMakerInstruction.Serialize);
        }
    }
}
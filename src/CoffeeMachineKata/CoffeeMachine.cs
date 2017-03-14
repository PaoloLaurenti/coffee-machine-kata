using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachineKata
{
    public class CoffeeMachine
    {
        private readonly IDrinkMaker _drinkMaker;
        private readonly Dictionary<BeverageType, DrinkMakerInstructionBuilder> _drinkMakerInstructions;

        public CoffeeMachine(IDrinkMaker drinkMaker)
        {
            _drinkMaker = drinkMaker;
            _drinkMakerInstructions = new Dictionary<BeverageType, DrinkMakerInstructionBuilder>
            {
                {BeverageType.Tea, new DrinkMakerInstructionBuilder("T")},
                {BeverageType.Coffee, new DrinkMakerInstructionBuilder("C")},
                {BeverageType.Chocolate, new DrinkMakerInstructionBuilder("H")}
            };
        }
            
        public void Dispense(Beverage beverage)
        {
            var drinkMakerInstruction = _drinkMakerInstructions[beverage.Type];

            if(beverage.SugarAmount > 0)
                drinkMakerInstruction.WithSugar();

            _drinkMaker.Make(drinkMakerInstruction.Build);
        }
    }
}
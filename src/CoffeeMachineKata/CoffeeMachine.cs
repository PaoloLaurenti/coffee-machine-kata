using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachineKata
{
    public class CoffeeMachine
    {
        private readonly IDrinkMaker _drinkMaker;
        private readonly Dictionary<BeverageType, DrinkMakerInstructionBuilder> _drinkMakerInstructionBuilders;

        public CoffeeMachine(IDrinkMaker drinkMaker)
        {
            _drinkMaker = drinkMaker;
            _drinkMakerInstructionBuilders = new Dictionary<BeverageType, DrinkMakerInstructionBuilder>
            {
                {BeverageType.Tea, new DrinkMakerInstructionBuilder("T")},
                {BeverageType.Coffee, new DrinkMakerInstructionBuilder("C")},
                {BeverageType.Chocolate, new DrinkMakerInstructionBuilder("H")}
            };
        }

        public void Dispense(Beverage beverage)
        {
            var instruction = _drinkMakerInstructionBuilders[beverage.Type]
                                .WithSugar(beverage.SugarAmount)
                                .Build;
            _drinkMaker.Make(instruction);
        }
    }
}
namespace CoffeeMachineKata
{
    public class CoffeeMachine
    {
        private readonly IDrinkMaker _drinkMaker;

        public CoffeeMachine(IDrinkMaker drinkMaker)
        {
            _drinkMaker = drinkMaker;
        }

        public void Dispense(Beverage beverage)
        {
            if (beverage.Type == BeverageType.Tea)
                _drinkMaker.Make("T::");
        }
    }
}
namespace CoffeeMachineKata
{
    public class Beverage
    {
        public BeverageType Type { get; }
        public ushort SugarAmount { get; }

        public Beverage(BeverageType type, ushort sugarAmount)
        {
            Type = type;
            SugarAmount = sugarAmount;
        }
    }
}
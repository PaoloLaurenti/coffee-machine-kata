namespace CoffeeMachineKata
{
    public class Beverage
    {
        public BeverageType Type { get; }

        public Beverage(BeverageType type, ushort sugarAmount)
        {
            Type = type;
        }
    }
}
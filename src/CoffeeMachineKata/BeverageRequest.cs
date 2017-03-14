namespace CoffeeMachineKata
{
    public class BeverageRequest
    {
        public BeverageType Type { get; }
        public ushort SugarAmount { get; }

        public BeverageRequest(BeverageType type, ushort sugarAmount)
        {
            Type = type;
            SugarAmount = sugarAmount;
        }
    }
}
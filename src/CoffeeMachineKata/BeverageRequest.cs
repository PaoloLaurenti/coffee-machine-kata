namespace CoffeeMachineKata
{
    public class BeverageRequest
    {
        public BeverageType Type { get; }
        public ushort SugarAmount { get; }
        public decimal Money { get; }

        public BeverageRequest(BeverageType type, ushort sugarAmount, decimal money)
        {
            Type = type;
            SugarAmount = sugarAmount;
            Money = money;
        }
    }
}
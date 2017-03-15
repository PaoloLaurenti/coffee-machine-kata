using System.Globalization;

namespace CoffeeMachineKata
{
    public class CoffeeMachine
    {
        private readonly IDrinkMakerMachine _drinkMakerMachine;
        private readonly Cashier _cashier;

        public CoffeeMachine(IDrinkMakerMachine drinkMakerMachine)
        {
            _drinkMakerMachine = drinkMakerMachine;
            _cashier = new Cashier();
        }

        public void Dispense(BeverageRequest beverageRequest)
        {
            _cashier.Checkout(beverageRequest, () => MakeBeverage(beverageRequest), ShowMissingMoney);
        }

        private void MakeBeverage(BeverageRequest beverageRequest)
        {
            var beverageInstruction = new DrinkMakerBeverageInstruction(beverageRequest.Type, beverageRequest.SugarAmount);
            _drinkMakerMachine.SendInstruction(beverageInstruction.ToString());
        }

        private void ShowMissingMoney(decimal money)
        {
            var message = money.ToString(CultureInfo.InvariantCulture);
            var messageInstruction = new DrinkMakerMessageInstruction(message).ToString();
            _drinkMakerMachine.SendInstruction(messageInstruction);
        }
    }
}
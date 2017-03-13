using FluentAssertions;
using Xunit;

namespace CoffeeMachineKata.Test
{
    public class CoffeeMachineTest
    {
        [Theory]
        [InlineData(BeverageType.Tea, "T::")]
        [InlineData(BeverageType.Coffee, "C::")]
        [InlineData(BeverageType.Chocolate, "H::")]
        public void MakeBeverageWithNoSugar(BeverageType type, string expectedCommand)
        {
            var drinkMakerSpy = new DrinkMakerSpy();
            var coffeeMachine = new CoffeeMachine(drinkMakerSpy);

            coffeeMachine.Dispense(new Beverage(type, 0));

            drinkMakerSpy.CommandsReceived.ShouldAllBeEquivalentTo(new[] {expectedCommand});
        }

        public void MakeMoreBeverages()
        {
            var drinkMakerSpy = new DrinkMakerSpy();
            var coffeeMachine = new CoffeeMachine(drinkMakerSpy);

            coffeeMachine.Dispense(new Beverage(BeverageType.Coffee, 0));
            coffeeMachine.Dispense(new Beverage(BeverageType.Tea, 0));
            coffeeMachine.Dispense(new Beverage(BeverageType.Chocolate, 0));
            coffeeMachine.Dispense(new Beverage(BeverageType.Tea, 0));

            drinkMakerSpy.CommandsReceived.ShouldAllBeEquivalentTo(new[] { "C::", "T::", "H::", "T::" });
        }
    }
}
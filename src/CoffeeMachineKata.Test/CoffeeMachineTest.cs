using FluentAssertions;
using Xunit;

namespace CoffeeMachineKata.Test
{
    public class CoffeeMachineTest
    {
        [Fact]
        public void MakeBeverageWithNoSugar()
        {
            var drinkMakerSpy = new DrinkMakerSpy();
            var coffeeMachine = new CoffeeMachine(drinkMakerSpy);

            coffeeMachine.Dispense(new Beverage(BeverageType.Tea, 0));

            drinkMakerSpy.CommandsReceived.ShouldAllBeEquivalentTo(new[] {"T::"});
        }
    }
}
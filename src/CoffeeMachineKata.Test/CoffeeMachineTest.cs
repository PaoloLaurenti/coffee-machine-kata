using FluentAssertions;
using Xunit;

namespace CoffeeMachineKata.Test
{
    public class CoffeeMachineTest
    {
        private readonly DrinkMakerSpy _drinkMakerSpy;
        private readonly CoffeeMachine _coffeeMachine;

        public CoffeeMachineTest()
        {
            _drinkMakerSpy = new DrinkMakerSpy();
            _coffeeMachine = new CoffeeMachine(_drinkMakerSpy);
        }

        [Theory]
        [InlineData(BeverageType.Tea, "T::")]
        [InlineData(BeverageType.Coffee, "C::")]
        [InlineData(BeverageType.Chocolate, "H::")]
        public void MakeBeverageWithNoSugar(BeverageType type, string expectedCommand)
        {
            _coffeeMachine.Dispense(new BeverageRequest(type, 0));

            _drinkMakerSpy.CommandsReceived.ShouldAllBeEquivalentTo(new[] {expectedCommand});
        }

        [Fact]
        public void MakeMoreBeverages()
        {
            _coffeeMachine.Dispense(new BeverageRequest(BeverageType.Coffee, 0));
            _coffeeMachine.Dispense(new BeverageRequest(BeverageType.Tea, 0));
            _coffeeMachine.Dispense(new BeverageRequest(BeverageType.Chocolate, 0));
            _coffeeMachine.Dispense(new BeverageRequest(BeverageType.Tea, 0));

            _drinkMakerSpy.CommandsReceived.ShouldAllBeEquivalentTo(new[] {"C::", "T::", "H::", "T::"});
        }

        [Theory]
        [InlineData(BeverageType.Tea, 1, "T:1:0")]
        [InlineData(BeverageType.Tea, 2, "T:2:0")]
        [InlineData(BeverageType.Coffee, 1, "C:1:0")]
        [InlineData(BeverageType.Coffee, 2, "C:2:0")]
        [InlineData(BeverageType.Chocolate, 1, "H:1:0")]
        [InlineData(BeverageType.Chocolate, 2, "H:2:0")]
        public void MakeBeverageWithSugarsAndAStick(BeverageType type, ushort sugarsAmount, string expectedCommand)
        {
            _coffeeMachine.Dispense(new BeverageRequest(type, sugarsAmount));

            _drinkMakerSpy.CommandsReceived.ShouldAllBeEquivalentTo(new[] { expectedCommand });
        }
    }
}
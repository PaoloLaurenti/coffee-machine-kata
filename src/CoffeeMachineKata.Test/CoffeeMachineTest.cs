using FluentAssertions;
using Xunit;

namespace CoffeeMachineKata.Test
{
    public class CoffeeMachineTest
    {
        private const decimal EnoughMoney = 100m;
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
            _coffeeMachine.Dispense(new BeverageRequest(type, 0, EnoughMoney));

            _drinkMakerSpy.CommandsReceived.ShouldAllBeEquivalentTo(new[] {expectedCommand});
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
            _coffeeMachine.Dispense(new BeverageRequest(type, sugarsAmount, EnoughMoney));

            _drinkMakerSpy.CommandsReceived.ShouldAllBeEquivalentTo(new[] { expectedCommand });
        }

        [Fact]
        public void MakeMoreBeverages()
        {
            _coffeeMachine.Dispense(new BeverageRequest(BeverageType.Coffee, 0, EnoughMoney));
            _coffeeMachine.Dispense(new BeverageRequest(BeverageType.Tea, 1, EnoughMoney));
            _coffeeMachine.Dispense(new BeverageRequest(BeverageType.Chocolate, 2, EnoughMoney));
            _coffeeMachine.Dispense(new BeverageRequest(BeverageType.Tea, 0, EnoughMoney));

            _drinkMakerSpy.CommandsReceived.ShouldAllBeEquivalentTo(new[] {"C::", "T:1:0", "H:2:0", "T::"});
        }

        [Theory]
        [InlineData(BeverageType.Tea, 0.3, "M:0.1")]
        [InlineData(BeverageType.Tea, 0.1, "M:0.3")]
        [InlineData(BeverageType.Coffee, 0.1, "M:0.5")]
        [InlineData(BeverageType.Coffee, 0.5, "M:0.1")]
        [InlineData(BeverageType.Chocolate, 0.1, "M:0.4")]
        [InlineData(BeverageType.Chocolate, 0.4, "M:0.1")]
        public void NotEnoughMoney(BeverageType type, decimal money, string expectedDrinkMakerMessage)
        {
            _coffeeMachine.Dispense(new BeverageRequest(type, 1, money));

            _drinkMakerSpy.CommandsReceived.ShouldAllBeEquivalentTo(new[] { expectedDrinkMakerMessage });
        }
    }
}
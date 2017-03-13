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
            _coffeeMachine.Dispense(new Beverage(type, 0));

            _drinkMakerSpy.CommandsReceived.ShouldAllBeEquivalentTo(new[] {expectedCommand});
        }

        [Fact]
        public void MakeMoreBeverages()
        {
            _coffeeMachine.Dispense(new Beverage(BeverageType.Coffee, 0));
            _coffeeMachine.Dispense(new Beverage(BeverageType.Tea, 0));
            _coffeeMachine.Dispense(new Beverage(BeverageType.Chocolate, 0));
            _coffeeMachine.Dispense(new Beverage(BeverageType.Tea, 0));

            _drinkMakerSpy.CommandsReceived.ShouldAllBeEquivalentTo(new[] {"C::", "T::", "H::", "T::"});
        }

        //[Fact]
        //public void MakeTeaWithOneSugar()
        //{
        //    _coffeeMachine.Dispense(new Beverage(BeverageType.Tea, 1));

        //    _drinkMakerSpy.CommandsReceived.ShouldAllBeEquivalentTo(new[] {"T:1:0"});
        //}
    }
}
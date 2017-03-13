using System.Collections.Generic;

namespace CoffeeMachineKata.Test
{
    public class DrinkMakerSpy : IDrinkMaker
    {
        public DrinkMakerSpy()
        {
            CommandsReceived = new List<string>();
        }

        public List<string> CommandsReceived { get; }
        public void Make(string command)
        {
            CommandsReceived.Add(command);
        }
    }
}
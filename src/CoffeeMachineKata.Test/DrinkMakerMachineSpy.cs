using System.Collections.Generic;

namespace CoffeeMachineKata.Test
{
    public class DrinkMakerMachineSpy : IDrinkMakerMachine
    {
        public DrinkMakerMachineSpy()
        {
            CommandsReceived = new List<string>();
        }

        public List<string> CommandsReceived { get; }
        public void SendInstruction(string command)
        {
            CommandsReceived.Add(command);
        }
    }
}
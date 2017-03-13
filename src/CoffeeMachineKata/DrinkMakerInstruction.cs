namespace CoffeeMachineKata
{
    public class DrinkMakerInstruction
    {
        private readonly string _instructionPrefix;

        public DrinkMakerInstruction(string instructionPrefix)
        {
            _instructionPrefix = instructionPrefix;
        }

        public string Serialize => $"{_instructionPrefix}::";
    }
}
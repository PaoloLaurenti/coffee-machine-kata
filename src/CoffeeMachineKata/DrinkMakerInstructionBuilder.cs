namespace CoffeeMachineKata
{
    public class DrinkMakerInstructionBuilder
    {
        private readonly string _instructionPrefix;
        private int _sugarCount;

        public DrinkMakerInstructionBuilder(string instructionPrefix)
        {
            _instructionPrefix = instructionPrefix;
        }

        public string Build => $"{_instructionPrefix}:{SugarInstructionPart}:{StickInstructionPart}";
        private string SugarInstructionPart => _sugarCount == 0 ? "" : _sugarCount.ToString();
        private string StickInstructionPart => _sugarCount == 0 ? "" : "0";

        public DrinkMakerInstructionBuilder WithSugar(ushort sugarAmount)
        {
            _sugarCount += sugarAmount;
            return this;
        }
    }
}
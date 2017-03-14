namespace CoffeeMachineKata
{
    public class DrinkMakerInstruction
    {
        private readonly string _instructionPrefix;
        private int _sugarCount;

        public DrinkMakerInstruction(string instructionPrefix)
        {
            _instructionPrefix = instructionPrefix;
        }

        public string Serialize => $"{_instructionPrefix}:{SugarInstructionPart}:{StickInstructionPart}";
        private string SugarInstructionPart => _sugarCount == 0 ? "" : _sugarCount.ToString();
        private string StickInstructionPart => _sugarCount == 0 ? "" : "0";

        public void WithSugar()
        {
            _sugarCount++;
        }
    }
}
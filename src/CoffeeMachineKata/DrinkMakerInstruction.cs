using System.Collections.Generic;

namespace CoffeeMachineKata
{
    public class DrinkMakerInstruction
    {
        private readonly BeverageType _type;
        private readonly ushort _sugarAmount;
        private readonly Dictionary<BeverageType, string> _drinkMakerBeveragesNames;

        public DrinkMakerInstruction(BeverageType type, ushort sugarAmount)
        {
            _type = type;
            _sugarAmount = sugarAmount;
            _drinkMakerBeveragesNames = new Dictionary<BeverageType, string>
            {
                {BeverageType.Tea, "T"},
                {BeverageType.Coffee, "C"},
                {BeverageType.Chocolate, "H"}
            };
        }

        private string SugarInstructionPart => _sugarAmount == 0 ? "" : _sugarAmount.ToString();
        private string StickInstructionPart => _sugarAmount == 0 ? "" : "0";

        public override string ToString()
        {
            return $"{_drinkMakerBeveragesNames[_type]}:{SugarInstructionPart}:{StickInstructionPart}";
        }
    }
}
namespace CoffeeMachineKata
{
    internal class DrinkMakerMessageInstruction
    {
        private readonly string _message;

        internal DrinkMakerMessageInstruction(string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return $"M:{_message}";
        }
    }
}
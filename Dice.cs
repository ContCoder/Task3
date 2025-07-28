namespace Task3
{
    public class Dice
    {
        public int[] Values { get; set; } = new int[] { };
        public int RollDice()
        { 
           return SecureKeyGenerator.GenerateSecureRandomInt(0, Values.Length);
        }
    }
}
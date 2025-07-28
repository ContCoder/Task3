using System.Security.Cryptography;

namespace Task3
{
    public class Dice
    {
        public int[] Values { get; set; } = new int[] { };
        public int RollDice()
        {
            return RandomNumberGenerator.GetInt32(0, Values.Length);
        }
    }
}

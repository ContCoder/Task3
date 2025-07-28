using System.Security.Cryptography;

namespace Task3
{
    public static class FairNumber
    {
        public static int GetFairNumber( MenuSelection menu)
        {
            Console.WriteLine("I selected a random value in the range 0..5");

            int introll1 = RandomNumberGenerator.GetInt32(0, 6);
            byte[] securekeyroll1 = SecureKeyGenerator.GenerateSecureKey(32);
            var hmac = SecureKeyGenerator.HmacSha3(securekeyroll1, introll1);
            Console.WriteLine($"(HMAC={hmac})");

            Console.WriteLine("Add your number modulo 6.");
            var keyroll1 = menu.DisplayMenu(5);
            if (int.TryParse(keyroll1.ToString(), out int roll1Guess))
            {
                Console.WriteLine($"You selected: {roll1Guess}");
            }
            Console.WriteLine($"My number is: {introll1}");
            Console.WriteLine($"KEY= ({Convert.ToHexString(securekeyroll1) })");

            int fairvalue1 = (introll1 + roll1Guess) % 6;
            Console.WriteLine("The fair number is: " + fairvalue1);
        return fairvalue1;
        }
    }
}
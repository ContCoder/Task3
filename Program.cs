using System.IO.Pipes;
using System.Security.Cryptography;
using Task3;

class Program
{
    static void Main(string[] args)
    {


        int requiredParams = 3;
        if (args.Length < requiredParams)
        {
            Console.WriteLine($"This program requires at least {requiredParams} dices. You provided {args.Length}.");
            Console.WriteLine("Example: 1,2,3,4,5,6 1,2,3,4,5,6 1,2,3,4,5,6 ");
            Console.WriteLine("Please try again.");
            return;
        }
        Dictionary<string, int[]> diceCounts = ParseArguments.Parse(args);
        if (diceCounts.Count < requiredParams)
        {
            Console.WriteLine($"This program requires at least {requiredParams} dices. You provided {diceCounts.Count()}.");
            Console.WriteLine("Example: 1,2,3,4,5,6 1,2,3,4,5,6 1,2,3,4,5,6 ");
            Console.WriteLine("Please try again.");
            return;
        }
        if (diceCounts.Values.Any(v => v.Length < 6))
        {
            Console.WriteLine("Each dice must have at least six values.");
            Console.WriteLine("Example: 1,2,3,4,5,6 1,2,3,4,5,6 1,2,3,4,5,6 ");
            Console.WriteLine("Please try again.");
            return;
        }
        MenuSelection menu = new MenuSelection
        {
            configs = diceCounts.Keys.ToArray(),
            probabilities = Helper.CalculateAllProbabilities(diceCounts.Values.ToArray())
        };

        Console.WriteLine("Let's determine who makes the first move");
        Console.WriteLine("I selected a random value in the range 0..1");

        byte[] securekey = SecureKeyGenerator.GenerateSecureKey(32);
        int randomInt = RandomNumberGenerator.GetInt32(0, 2);
        string hmac = SecureKeyGenerator.HmacSha3(securekey, randomInt);
        Console.WriteLine($"(HMAC={hmac})");

        Console.WriteLine("Try yo guess my selection.");
        char key = menu.DisplayMenu(1);

        int howStart = 0;
        int userGuess = 0;
        while (!int.TryParse(key.ToString(), out userGuess))
        {
            key = menu.DisplayMenu(1);
        }

        if (userGuess == randomInt)
        {
            Console.WriteLine("Congratulations! You guessed my number.");
            howStart = 1; // User
        }
        else
        {
            Console.WriteLine("My number is: " + randomInt);
            Console.WriteLine("I make the first move.");

        }

        Console.WriteLine($"(KEY={Convert.ToHexString(securekey)})");

        Dice dice1 = new Dice();
        int dice1Index;
        if (howStart == 1)
        {
            Console.WriteLine("Select your dice.");
            var keydice1 = menu.DisplayMenu(diceCounts.Count() - 1, diceCounts.Values.Select(v => string.Join(", ", v)).ToArray());

            if (int.TryParse(keydice1.ToString(), out dice1Index))
            {
                dice1 = new Dice { Values = diceCounts.ElementAt(dice1Index).Value };
                Console.WriteLine($"You selected dice {dice1Index}: {string.Join(", ", dice1.Values)}");
            }

        }
        else
        {
            dice1Index = RandomNumberGenerator.GetInt32(0, diceCounts.Count);
            dice1 = new Dice { Values = diceCounts.ElementAt(dice1Index).Value };
            Console.WriteLine($"I selected dice {dice1Index}: {string.Join(", ", dice1.Values)}");
        }

        diceCounts.Remove(diceCounts.ElementAt(dice1Index).Key);

        Dice dice2 = new Dice();
        int dice2Index;

        if (howStart == 1)
        {
            dice2Index = RandomNumberGenerator.GetInt32(0, diceCounts.Count);
            dice2 = new Dice { Values = diceCounts.ElementAt(dice2Index).Value };
            Console.WriteLine($"I selected dice {dice2Index}: {string.Join(", ", dice2.Values)}");
        }
        else
        {
            Console.WriteLine("Select your dice.");
            var keydice2 = menu.DisplayMenu(diceCounts.Count() - 1, diceCounts.Values.Select(v => string.Join(", ", v)).ToArray());

            if (int.TryParse(keydice2.ToString(), out dice2Index))
            {
                dice2 = new Dice { Values = diceCounts.ElementAt(dice2Index).Value };
                Console.WriteLine($"You selected dice {dice2Index}: {string.Join(", ", dice2.Values)}");
            }
        }

        Console.WriteLine("Let's roll the dices!");

        var fairnumber1 = FairNumber.GetFairNumber(menu);

        Console.WriteLine("Lets roll the second dice.");

        var fairnumber2 = FairNumber.GetFairNumber(menu);

        var facedice1 = dice1!.Values[fairnumber1];
        var facedice2 = dice2!.Values[fairnumber2];

        bool userWins = false;
        if (howStart == 1)
        {
            userWins = facedice1 > facedice2;
        }
        else
        {
            userWins = facedice2 > facedice1;
        }

        if (facedice1 == facedice2)
        {
            Console.WriteLine("DRAW!");
        }
        else if (userWins)
        {
            Console.WriteLine($"You win ({(howStart == 1 ? facedice1 : facedice2)} > {(howStart == 1 ? facedice2 : facedice1)})");
        }
        else
        {
            Console.WriteLine($"Computer win ({(howStart == 1 ? facedice2 : facedice1)} > {(howStart == 1 ? facedice1 : facedice2)})");
        }

    }
}

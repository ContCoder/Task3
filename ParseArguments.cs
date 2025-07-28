namespace Task3
{
    public class ParseArguments
    {
        public static Dictionary<string, int[]> Parse(string[] args)
        {
            Dictionary<string, int[]> diceCounts = new Dictionary<string, int[]>();
            for (int i = 0; i < args.Length; i++)
            {
                string[] values = args[i].Split(',');
                IEnumerable<int> numbers = new int[] { };
                foreach (var value in values)
                {
                    if (int.TryParse(value, out int Number))
                    {
                        numbers = numbers.Append(Number);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid argument '{args[i]}'. Please provide valid integers.");
                        Console.WriteLine("Example: 1,2,3,4,5,6 1,2,3,4,5,6 1,2,3,4,5,6 ");
                        Console.WriteLine("Please try again.");
                        return diceCounts;
                    }
                }
                if (numbers.Any())
                {
                    diceCounts[$"Dice {i + 1}"] = numbers.ToArray();
                }
            }
            return diceCounts;
        }

    }
}


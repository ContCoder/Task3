namespace Task3
{
    public class MenuSelection
    {
        public string [] configs {get; set; } = new string[] { };
        public double[,] probabilities { get; set; } = new double[0, 0]; 
        public char DisplayMenu(int opt, string[] values = null)
        {
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║               MENÚ                 ║");
            Console.WriteLine("╠════════════════════════════════════╣");
            for (int i = 0; i <= opt; i++)
            {
                if (values == null)
                {
                    Console.WriteLine($"║  {i} - {i}                             ║");
                }
                else
                {
                    Console.WriteLine($"║  {i} - {values[i]}                             ");
                }
            }
            Console.WriteLine("║  X - exit                          ║");
            Console.WriteLine("║  ? - help                          ║");
            Console.WriteLine("╚════════════════════════════════════╝");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char key = keyInfo.KeyChar;
            ProcessSelection(key);
            return key;
        }
        private void ProcessSelection(char key)
        {
            switch (key)
            {
                case 'x':
                    Environment.Exit(0);
                    break;
                case '?':
                    Helper.ShowDynamicHelp(configs, probabilities);
                    break;
                default:
                    Console.WriteLine($"Your selection: {key}");
                    break;
            }
        }
    }


}

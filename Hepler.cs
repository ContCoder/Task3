using ConsoleTables;
namespace Task3
{
    public static class Helper
    {

        // Versión dinámica (para dados con números grandes) - Solo 12 líneas
        public static void ShowDynamicHelp(string[] diceConfigs, double[,] probabilities)
        {
            Console.WriteLine("Probability of the win for the user:");

            var headers = new List<string> { "User dice v" };
            headers.AddRange(diceConfigs);

            var table = new ConsoleTable(headers.ToArray());
            table.Options.EnableCount = false; // Desactivar el conteo de filas

            // Agregar cada fila
            for (int i = 0; i < diceConfigs.Length; i++)
            {
                var row = new List<object> { diceConfigs[i] };
                for (int j = 0; j < diceConfigs.Length; j++)
                {
                    row.Add(probabilities[i, j].ToString("F4"));
                }
                table.AddRow(row.ToArray());
            }

            table.Write();
        }

        public static double[,] CalculateAllProbabilities(int[][] diceConfigs)
        {
            int n = diceConfigs.Length;
            double[,] probabilities = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int wins = diceConfigs[i].Sum(x => diceConfigs[j].Count(y => x > y));
                    probabilities[i, j] = (double)wins / (diceConfigs[i].Length * diceConfigs[j].Length);
                }
            }

            return probabilities;
        }

    }
}
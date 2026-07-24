namespace ShopEaseConsoleApp.Utils
{
    public static class ConsoleHelper
    {
        public static string ReadNonEmptyString(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Value cannot be empty. Try again.");
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        public static int ReadInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;
                Console.WriteLine("Please enter a valid whole number.");
            }
        }

        public static decimal ReadDecimal(string prompt)
        {
            decimal value;
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out value))
                    return value;
                Console.WriteLine("Please enter a valid number.");
            }
        }

        public static double ReadDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value))
                    return value;
                Console.WriteLine("Please enter a valid number.");
            }
        }

        public static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static void PrintHeader(string title)
        {
            Console.Clear();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine(title.PadLeft((50 + title.Length) / 2));
            Console.WriteLine(new string('=', 50));
        }

        public static void PrintError(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }

        public static void PrintSuccess(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }
    }
}

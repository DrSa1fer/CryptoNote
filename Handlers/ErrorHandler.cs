namespace CryptoNote.Handlers
{
    internal class ErrorHandler
    {
        public static void ArgumentCountError(string name, int count)
        {
            SetColorWhile(ConsoleColor.Red, 
                () => Console.WriteLine($">>> Argument Error. Function({name}) take {count} argument{(count > 1 ? "s" : "")}"));
        }
        public static void ArgumentError(string name, string arg)
        {
            SetColorWhile(ConsoleColor.Red,
                () => Console.WriteLine($">>> {name} is not contains {arg}"));
        }
        public static void UnknownFunction(string line)
        {
            SetColorWhile(ConsoleColor.Red,
                () => Console.WriteLine($">>> Function is unknown. Line: {line}"));            
        }
        private static void SetColorWhile(ConsoleColor color, Action action)
        {
            Console.ForegroundColor = color;
            action?.Invoke();
            Console.ResetColor();
        }
    }
}
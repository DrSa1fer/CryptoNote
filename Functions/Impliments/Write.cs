using CryptoNote.Savers;

namespace CryptoNote.Functions
{
    internal class Write : BaseFunctionWithArgs
    {
        public override string Name => "write";
        public override string ShortName => "w";
        public override string Description => "записывает данные в файл";
        public override string Example => $"[{Name}|{ShortName}] [filename]";

        public override void Invoke(params string[] args)
        {
            LocalSaver.Save(args[0], FileWritingMode());
        }

        private static string[] FileWritingMode()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            var list = new List<string>();
            var exit = "\\save";

            Console.WriteLine($">>> Start file writing. For exit write \"{exit}\"");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == exit)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(">>> End file writing");
                    break;
                }
                list.Add(input!);
            }
            Console.ResetColor();
            return list.ToArray();
        }
    }
}
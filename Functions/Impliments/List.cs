using CryptoNote.Handlers;
using CryptoNote.Savers;

namespace CryptoNote.Functions
{
    internal class List : BaseFunctionWithArgs
    {
        public override string Name => "list";
        public override string ShortName => "l";
        public override string Description => "выводит список файлов";
        public override string Example => $"[{Name}|{ShortName}] [{NAME_KEY}|n] | [{FULL_KEY}|f]";

        private const string NAME_KEY = "name";
        private const string FULL_KEY = "fullPath";

        public override void Invoke(params string[] args)
        {
            var files = LocalSaver.GetAllFiles();
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (files.Length == 0)
            {
                Console.WriteLine(" => Not files");
                Console.ResetColor();
                return;
            }

            if (args[0] == "name" || args[0] == "n")
            {
                foreach (var i in files)
                {
                    Console.WriteLine($" => {i[(i.LastIndexOf('\\') + 1)..]}");
                }
                Console.ResetColor();
                return;
            }
            if (args[0] == "full" || args[0] == "f")
            {
                foreach (var i in files)
                {
                    Console.WriteLine($" => {i}");
                }
                Console.ResetColor();
                return;
            }

            ErrorHandler.ArgumentError(Name, args[0]);
        }
    }
}
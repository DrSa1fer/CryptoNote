using CryptoNote.Savers;

namespace CryptoNote.Functions
{
    internal class Read : BaseFunctionWithArgs
    {
        public override string Name => "read";
        public override string ShortName => "r";
        public override string Description => "читает файл";
        public override string Example => $"[{Name}|{ShortName}] [filename]";

        public override void Invoke(params string[] args)
        {
            var files = LocalSaver.GetAllFiles();

            foreach (var file in files)
            {
                var name = file[(file.LastIndexOf("\\") + 1)..];

                if (!name.StartsWith(args[0])) continue;

                if (LocalSaver.TryLoad(name[..name.LastIndexOf('.')], out string text))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($">>> File: {name}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine(text);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(">>> End file");
                    Console.ResetColor();
                    return;
                }
            }

        }
    }
}
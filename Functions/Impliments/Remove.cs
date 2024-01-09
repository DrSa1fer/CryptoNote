using CryptoNote.Savers;

namespace CryptoNote.Functions
{
    internal class Remove : BaseFunctionWithArgs
    {
        public override string Name => "remove";
        public override string ShortName => "rm";
        public override string Description => "удаляет файл";
        public override string Example => $"[{Name}|{ShortName}] [filename]";

        public override void Invoke(params string[] args)
        {
            LocalSaver.Remove(args[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"File removed: {args[0]}");
            Console.ResetColor();
        }
    }
}
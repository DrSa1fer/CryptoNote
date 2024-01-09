namespace CryptoNote.Functions
{
    internal class Help : BaseFunctionWithoutArgs
    {
        public override string Name => "help";
        public override string ShortName => "h";
        public override string Description => "выводит список команд";
        public override string Example => $"[{Name}|{ShortName}]";

        private IReadOnlyCollection<BaseFunction>? _collection;
        
        public void Inject(IReadOnlyCollection<BaseFunction> collection)
        {
            _collection = collection;
        }

        public override void Invoke()
        {
            if (_collection == null)
            {
                return;
            }
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.CursorLeft = 0;
            Console.Write("Name");

            Console.CursorLeft = 10;
            Console.Write("Short");

            Console.CursorLeft = 18;
            Console.Write("Description");

            Console.CursorLeft = 48;
            Console.Write("Example");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var i in _collection)
            {
                Console.CursorLeft = 0;                
                Console.Write($"{i.Name}");

                Console.CursorLeft = 10;
                Console.Write($"{i.ShortName}");
                
                Console.CursorLeft = 18;
                Console.Write($"{i.Description}");

                Console.CursorLeft = 48;
                Console.Write($"{i.Example}");

                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}

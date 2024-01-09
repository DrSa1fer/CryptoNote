namespace CryptoNote.Functions
{
    internal class Clear : BaseFunctionWithoutArgs
    {
        public override string Name => "clear";
        public override string ShortName => "c";
        public override string Description => "очищает консоль";

        public override string Example => $"[{Name}|{ShortName}]";

        public override void Invoke()
        {
            Console.Clear();
        }
    }
}
namespace CryptoNote
{
    internal class Help : IFunction
    {
        public string Name => "help";
        public string ShortName => "h";
        public string Description => "выводит список команд";
        public string Example => "help";

        private readonly List<IFunction> _list;
        public Help(List<IFunction> list)
        {
            _list = list;
        }

        public void Invoke()
        {
            foreach(var i in _list)
            {
                Console.WriteLine($"{i.Name} or {i.ShortName} => {i.Example} {i.Description}");
            }
        }
    }
}

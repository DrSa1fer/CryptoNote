using CryptoNote.Functions;

namespace CryptoNote
{
    internal class FunctionRepository
    {
        private readonly List<BaseFunctionWithArgs> _funcWithArgs = new();
        private readonly List<BaseFunctionWithoutArgs> _funcWithoutArgs = new();

        public FunctionRepository()
        {
            var help = new Help();            
            AddFunc(help);            
            AddFunc(new Clear());
            AddFunc(new List());
            AddFunc(new Read());
            AddFunc(new Remove());
            AddFunc(new Write());

            help.Inject(Functions);
        }

        public bool TryGetFunctionWithoutArgs(string name, out BaseFunctionWithoutArgs? func)
        {
            return (func = _funcWithoutArgs.Find(x => x.IsEqualByName(name))) != null;
        }
        public bool TryGetFunctionWithArgs(string name, out BaseFunctionWithArgs? func)
        {
            return (func = _funcWithArgs.Find(x => x.IsEqualByName(name))) != null;
        }

        public void AddFunc(BaseFunctionWithArgs func)
        {
            _funcWithArgs.Add(func);
        }
        public void AddFunc(BaseFunctionWithoutArgs func)
        {
            _funcWithoutArgs.Add(func);
        }

        public IReadOnlyCollection<BaseFunction> Functions
        {
            get
            {
                var list = new List<BaseFunction>();
                foreach (var i in _funcWithArgs)
                {
                    list.Add(i);
                }
                foreach (var i in _funcWithoutArgs)
                {
                    list.Add(i);
                }
                return list;
            }
        }
    }
}
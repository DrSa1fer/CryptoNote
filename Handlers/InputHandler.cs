using CryptoNote.Functions;

namespace CryptoNote.Handlers
{
    internal class InputHandler
    {
        private readonly FunctionRepository _rep;

        public InputHandler(FunctionRepository rep)
        {
            _rep = rep;
        }

        public void Update(string line)
        {
            var arr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (arr.Length == 1)
            {
                if (_rep.TryGetFunctionWithoutArgs(arr[0], out BaseFunctionWithoutArgs? func))
                {
                    func?.Invoke();
                    return;
                }
            }
            if (arr.Length > 1)
            {
                if (_rep.TryGetFunctionWithArgs(arr[0], out BaseFunctionWithArgs? func))
                {
                    func?.Invoke(arr[1..]);
                    return;
                }
            }
            ErrorHandler.UnknownFunction(line);
        }
    }
}
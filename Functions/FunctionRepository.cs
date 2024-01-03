namespace CryptoNote;
internal class FunctionRepository
{
    private readonly List<IFunction> _list = new();

    public FunctionRepository()
    {
        _list.Add(new Read());
        _list.Add(new Write());
        _list.Add(new Remove());
        _list.Add(new Clear());
        _list.Add(new List());
        _list.Add(new Help(_list));
    }
    public bool TryGetFunction(string name, out IFunction? func) 
    {
         return (func = _list.Find(x => x.IsEqualByName(name))) != null;
    }
}

namespace CryptoNote;
internal class InputHandler
{
    public static string[] Arguments { get; private set; } = Array.Empty<string>();
    private readonly FunctionRepository _rep = new();

    public void Update(string line)
    {
        var arr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (arr.Length == 0) return;
        Arguments = arr.Length > 1 ? arr[1..] : Array.Empty<string>();

        if (_rep.TryGetFunction(arr[0], out IFunction? func)) func?.Invoke();           
    }
}
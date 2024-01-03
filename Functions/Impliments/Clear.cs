namespace CryptoNote;
internal class Clear : IFunction
{
    public string Name => "clear";
    public string ShortName => "c";
    public string Description => "очищает консоль";
    public string Example => "clear";

    public void Invoke()
    {
        Console.Clear();
    }
}
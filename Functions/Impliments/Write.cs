namespace CryptoNote;
internal class Write : IFunction
{
    public string Name => "write";
    public string ShortName => "w";
    public string Description => "записывает данные в файл";
    public string Example => "write filename";

    public void Invoke()
    {
        var args = InputHandler.Arguments;

        if (args.Length == 1)
        {
            LocalSaver.Save(args[0], FileWritingMode());            
            return;
        }
        ErrorHandler.ArgumentError($"write take one argument: filename");
    }
    private static string[] FileWritingMode()
    {
        var list = new List<string>();
        var exit = "\\save";

        Console.WriteLine($">>> Start file writing. For exit write \"{exit}\"");
        Console.WriteLine();
        while (true)
        {
            var input = Console.ReadLine();
            if (input == exit)
            {
                Console.WriteLine();
                Console.WriteLine(">>> End file writing");
                break; 
            }
            list.Add(input!);
        }
        return list.ToArray();
    }
}
namespace CryptoNote;

internal class Read : IFunction
{
    public string Name => "read";
    public string ShortName => "r";
    public string Description => "читает файл";
    public string Example => "read filename";

    public void Invoke()
    {
        var args = InputHandler.Arguments;
        if (args.Length != 1)
        {
            ErrorHandler.ArgumentError($"read take one argument: filename");
            return;
        }
        var files = LocalSaver.GetAllFiles();
        foreach(var file in files )
        {
            var name = file[(file.LastIndexOf("\\") + 1)..];
            
            if (!name.StartsWith(args[0])) continue;

            if (LocalSaver.TryLoad(name[..name.LastIndexOf('.')], out string text))
            {
                Console.WriteLine($">>> File: {name}");
                Console.WriteLine();
                Console.WriteLine(text);
                Console.WriteLine();
                Console.WriteLine(">>> End file");
                return;
            }            
        }
        
    }
}

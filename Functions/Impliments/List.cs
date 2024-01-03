namespace CryptoNote;
internal class List : IFunction
{
    public string Name => "list";
    public string ShortName => "l";
    public string Description => "выводит список файлов";
    public string Example => "list"; 

    public void Invoke()
    {
        var files = LocalSaver.GetAllFiles();
        if (files.Length == 0)
        {
            Console.WriteLine(" => Not files");
            return;
        }

        if (InputHandler.Arguments.Length > 0 && InputHandler.Arguments[0] == "name")
        {
            foreach (var i in files)
            {
                Console.WriteLine($" => {i[(i.LastIndexOf('\\') + 1)..]}");
            }
            return;
        }

        foreach (var i in files)
        {
            Console.WriteLine($" => {i}");
        }
    }
}

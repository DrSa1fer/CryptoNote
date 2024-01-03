namespace CryptoNote;
internal class Remove : IFunction
{
    public string Name => "remove";
    public string ShortName => "rm";
    public string Description => "удаляет файл";
    public string Example => "remove filename";

    public void Invoke()
    {
        if(InputHandler.Arguments.Length == 1)
        {
            LocalSaver.Remove(InputHandler.Arguments[0]);
            return;
        }
        ErrorHandler.ArgumentError($"remove take one argument: filename");
    }
}
namespace CryptoNote;
internal class ErrorHandler
{
    public static void ArgumentError(string msg)
    {
        Console.WriteLine($">>> Argument Error: {msg}");
    }
}

namespace CryptoNote;
internal class Program
{
    private static void Main(string[] args)
    {
        var handler = new InputHandler();
        Console.WriteLine("Use help for information");
        while (true)
        {
            var input = Console.ReadLine();
            if (input == null) continue;

            handler.Update(input);
        }
    }
}
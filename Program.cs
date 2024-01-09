using CryptoNote.Handlers;

namespace CryptoNote;
internal class Program
{
    private static void Main(string[] args)
    {
        var rep = new FunctionRepository();
        var handler = new InputHandler(rep);






        Console.WriteLine("Use help for information");

        while (true)
        {
            var input = Console.ReadLine();
            if (input == null) continue;

            handler.Update(input);
        }
    }
}
namespace CryptoNote.Functions
{
    internal abstract class BaseFunction
    {
        public abstract string Name { get; }
        public abstract string ShortName { get; }
        public abstract string Description { get; }
        public abstract string Example { get; }
        public bool IsEqualByName(string name)
        {
            return Name == name || ShortName == name;
        }
    }
}
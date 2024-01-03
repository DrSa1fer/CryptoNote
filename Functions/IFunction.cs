namespace CryptoNote;
internal interface IFunction
{
    public string Name { get; }
    public string ShortName { get; }
    public string Description { get; }
    public string Example { get; }
    public void Invoke();
    public bool IsEqualByName(string name)
    {
        return Name == name || ShortName == name; 
    }
}

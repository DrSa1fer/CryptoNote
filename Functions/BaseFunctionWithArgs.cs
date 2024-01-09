namespace CryptoNote.Functions
{
    internal abstract class BaseFunctionWithArgs : BaseFunction
    {
        public abstract void Invoke(params string[] args);
    }
}

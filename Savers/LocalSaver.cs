using CryptoLib;

namespace CryptoNote;
public static class LocalSaver
{
    private static readonly IChiper _chiper = new VisionerChiper();
    private static string DirectoryPath
    {
        get
        {
            var str = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return $@"{str}\CryptoNote\Note\";
        }
    }

    private static string BuildFilePath(string name)
    {
        return $@"{DirectoryPath}{name}.crypt";
    }
    public static string[] GetAllFiles()
    {
        return Directory.GetFiles(DirectoryPath);
    }

    public static void Save(string name, params string[] text)
    {
        if(!Directory.Exists(DirectoryPath))
        { 
            Directory.CreateDirectory(DirectoryPath);
        }

        var arr = new string[text.Length];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = _chiper.Encrypt(text[i]);
        }
        
        File.WriteAllLines(BuildFilePath(name), arr);        
    }
    public static bool TryLoad(string name, out string text)
    {
        var path = BuildFilePath(name);
        if (File.Exists(path))
        {
            var arr = File.ReadAllLines(path);                
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = _chiper.Decrypt(arr[i]);
            }
            text = string.Join('\n', arr);
            return true;
        }
        text = "";
        return false;
    }
    public static void Remove(string name)
    {
        var path = BuildFilePath(name);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
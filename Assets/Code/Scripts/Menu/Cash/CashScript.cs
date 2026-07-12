using System.IO;
using Newtonsoft.Json;

public static class CashScript
{
    private static uint cashNumber = 0;

    public static void Add(uint num)
    {
        cashNumber += num;
        Save();
    }

    public static uint GetCashValue()
    {
        return cashNumber;
    }

    public static bool Subtract(uint num)
    {
        if (cashNumber >= num)
        {
            cashNumber -= num;
            Save();
            return true;
        }
        return false;
    }
    //Господи помоги мне докодить эту игру до конца _/\_ T0T
    public static void Save()
    {
        string jsonString = JsonConvert.SerializeObject(cashNumber);
        File.WriteAllText(Settings.CashDirectoryPath, jsonString);
    }

    public static void Load()
    {
        if (File.Exists(Settings.CashDirectoryPath))
        {
            string jsonString = File.ReadAllText(Settings.CashDirectoryPath);
            cashNumber = JsonConvert.DeserializeObject<uint>(jsonString);
        }
    }
}

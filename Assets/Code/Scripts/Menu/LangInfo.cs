using System.Collections.Generic;

public class LangInfo
{
    public LangInfo(Dictionary<string, string> lg, string lgName)
    {
        lang = lg;
        langName = lgName;
    }
    public Dictionary<string, string> lang;
    public string langName;
}

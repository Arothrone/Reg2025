using System.Collections.Generic;

public class DropdownLang : DropdownDef
{
    override protected void ChangeDropdownValue()
    {
        
        dropdownGO.SetValueWithoutNotify(Settings.currentSettings.languageIndex);
    }
    override public void SetValues()
    {
        List<string> options = new List<string>();
        foreach (LangInfo info in CurrentLanguage.langs)
        {
            options.Add(info.langName);
        }
        dropdownGO.AddOptions(options);
        ChangeDropdownValue();
    }

    override public void Action()
    {
        
        Settings.currentSettings.languageIndex = dropdownGO.value;
    }
}

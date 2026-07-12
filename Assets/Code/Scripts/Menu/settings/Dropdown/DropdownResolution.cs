using System.Collections.Generic;

public class DropdownResolution : DropdownDef
{
    override protected void ChangeDropdownValue()
    {
        
        dropdownGO.SetValueWithoutNotify(Settings.currentSettings.resolutionIndex);
    }
    override public void SetValues()
    {
        List<string> options = new List<string>();
        foreach (Resolution res in Resolution.defaultResolutions)
        {
            options.Add(res.StringConvert());
        }
        dropdownGO.AddOptions(options);
        ChangeDropdownValue();
    }

    override public void Action()
    {
        Settings.currentSettings.resolutionIndex = dropdownGO.value;
    }
}

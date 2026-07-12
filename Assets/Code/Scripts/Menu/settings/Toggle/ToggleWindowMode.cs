

public class ToggleWindowMode : ToggleScript
{
    override public void Action()
    {
        Settings.currentSettings.window_mode = turned;
    }

    override protected void ChangeTurnedValUpd()
    {
        turned = Settings.currentSettings.window_mode;
        
    }
}

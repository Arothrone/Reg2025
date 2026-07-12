

using UnityEngine;

public class ToggleSound : ToggleScript
{
    override public void Action()
    {
        Settings.currentSettings.sounds = turned;
        if (turned)
        {
            AudioListener.volume = 1f;
        } else
        {
            AudioListener.volume = 0f;
        }
    }
    override protected void ChangeTurnedValUpd()
    {
        turned = Settings.currentSettings.sounds;
        
    }
}

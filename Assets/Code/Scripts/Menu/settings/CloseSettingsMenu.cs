using UnityEngine;

public class CloseSettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject saveWindow;
    [SerializeField] GameObject settingWindow;
    public void Close()
    {
        
        if (Settings.currentSettings.Equals(Settings.previousSettings))
        {
            settingWindow.SetActive(false);
        } else {
            saveWindow.SetActive(true);
        }
    }
}

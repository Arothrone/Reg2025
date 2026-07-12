using UnityEngine;

public class ResetSettingsButton : MonoBehaviour
{
    public void OnResetButtonPressed()
    {
        Settings.ResetCurrentSettings();
    }
}

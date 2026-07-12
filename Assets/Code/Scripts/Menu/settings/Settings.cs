using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class Settings
{
    public static string home;
    static public string LocalizatonDirectoryPath;
    static public string SettingsStateDirectoryPath;
    static public string CashDirectoryPath;
    public static string bgPath;
    public static string bgIdPath;
    public static string editorScenesPath;
    public static string editorScenesIndexPath;

    public static void SetPaths()
    {
        home = Application.persistentDataPath;
        editorScenesPath = Path.Combine(home, OnLoadGame.directoriesToCheck[0]);
        LocalizatonDirectoryPath = Path.Combine(home, OnLoadGame.directoriesToCheck[1]);
        SettingsStateDirectoryPath = Path.Combine(home, OnLoadGame.filesToCopy[0]);
        bgPath = Path.Combine(home, OnLoadGame.filesToCopy[1]);
        bgIdPath = Path.Combine(home, OnLoadGame.filesToCopy[2]);
        CashDirectoryPath = Path.Combine(home, OnLoadGame.filesToCopy[3]);
        editorScenesIndexPath = Path.Combine(home, OnLoadGame.filesToCopy[4]);
    }

    static public void RestorePreviousSettings()
    {
        Settings.currentSettings = Settings.previousSettings.Clone();
        Settings.currentSettings.UpdateSettings();
    }

    static public void ResetCurrentSettings()
    {
        Settings.currentSettings = new Settings();
        Settings.currentSettings.UpdateSettings();
    }

    static public void CurrentSettingsUpdateAndUpply()
    {
        Settings.currentSettings.UpdateAndApply();
    }

    public Settings(int resolutionIndexInit, bool window_modeInit, bool soundsInit, int languageIndexInit)
    {
        resolutionIndex = resolutionIndexInit;
        window_mode = window_modeInit;
        sounds = soundsInit;
        languageIndex = languageIndexInit;
    }
    public Settings()
    {
    }

    public void ApplySettings()
    {
        Resolution.defaultResolutions[resolutionIndex].SetCustomResolution(!window_mode);

        if (sounds)
        {
            AudioListener.volume = 1f;
        }
        else
        {
            AudioListener.volume = 0f;
        }
    }

    public void UpdateSettings()
    {
        TextLanguageSetScript.RestartLanguage();

        ToggleScript.UpdateToggles();

        DropdownDef.UpdateValue();

        
    }

    public void UpdateAndApply()
    {
        currentSettings = this.Clone();
        previousSettings = this.Clone();
        UpdateSettings();
        ApplySettings();
        SerializeAndSave();
    }

    private void SerializeAndSave()
    {
        string json = JsonConvert.SerializeObject(this);

        File.WriteAllText(SettingsStateDirectoryPath, json);
    }

    public Settings Clone()
    {
        return new Settings
        {
            resolutionIndex = this.resolutionIndex,
            window_mode = this.window_mode,
            sounds = this.sounds,
            languageIndex = this.languageIndex
        };
    }

    public bool Equals(Settings obj)
    {
        return resolutionIndex == obj.resolutionIndex && window_mode == obj.window_mode && 
        sounds == obj.sounds && languageIndex == obj.languageIndex;
    }
    
    [NonSerialized] public static Settings currentSettings = new Settings();
    [NonSerialized] public static Settings previousSettings = new Settings();

    [SerializeField] public int resolutionIndex = 0;
    [SerializeField] public bool window_mode = false;
    [SerializeField] public bool sounds = true;
    [SerializeField] public int languageIndex = 0;
}

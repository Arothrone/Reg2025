using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;



public class OnLoadGame : MonoBehaviour
{
    public static string[] filesToCopy = {Path.Combine("Resources", "Settings", "settingsState.json"),
        Path.Combine("Resources", "Backgrounds", "bg.json"),
        Path.Combine("Resources", "Backgrounds", "bg_id.json"),
        Path.Combine("Resources", "CashHolder", "cash.json"),
        Path.Combine("Resources", "Levels", "Ind", "scene_index.json"),
        Path.Combine("Resources", "Localizaton", "en1.json"),
        Path.Combine("Resources", "Localizaton", "ru1.json"),

    };

    public static string[] directoriesToCheck = {Path.Combine("Resources", "Levels"),
        Path.Combine("Resources", "Localizaton")};

    IEnumerator Start()
    {

        Settings.SetPaths();

        foreach (string fileName in filesToCopy)
        {
            string destPath = Path.Combine(Application.persistentDataPath, fileName);

            if (!File.Exists(destPath))
            {
                yield return StartCoroutine(CopyFile(fileName, destPath));
            }
        }


        foreach (string directoryName in directoriesToCheck)
        {
            string destPath = Path.Combine(Application.persistentDataPath, directoryName);
            if (!Directory.Exists(destPath)) Directory.CreateDirectory(destPath);
        }
        

        LoadAllLanguagesFromJson();
        LoadSettings();
        BgInfoScript.LoadBackgrounds();
        HandleEditorLogic.LoadScenesFrom();
        CashScript.Load();
        SceneManager.LoadScene(1);
    }

    IEnumerator CopyFile(string fileName, string destPath)
    {
        string sourcePath = Path.Combine(Application.streamingAssetsPath, fileName);

        string directory = Path.GetDirectoryName(destPath);
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

        using (UnityWebRequest request = UnityWebRequest.Get(sourcePath))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                File.WriteAllBytes(destPath, request.downloadHandler.data);
                Debug.Log($"Successfully copied: {fileName}");
            }
            else
            {
                Debug.LogError($"Error copying {fileName}: {request.error}");
            }
        }
    }


    static public void DefaultSettings()
    {
        Settings defS = new Settings();

        defS.UpdateAndApply();
    }

    static public void LoadSettings()
    {
        try
        {
            string jsonString = File.ReadAllText(Settings.SettingsStateDirectoryPath);
            Settings wrapper = JsonConvert.DeserializeObject<Settings>(jsonString);

            wrapper.UpdateAndApply();
        } catch (Exception)
        {
            Debug.Log("Saved settings did not load.");
            DefaultSettings();
        }
    }

    void LoadAllLanguagesFromJson()
    {
        IEnumerable<string> files = Directory.EnumerateFiles(Settings.LocalizatonDirectoryPath);

        foreach (string file in files)
        {
            string filename = Path.GetFileName(file);
            if (filename.EndsWith(".json"))
            {
                try
                {
                    string jsonString = File.ReadAllText(file);
                    
                    Dictionary<string, string> wrapper = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
                    
                    LangInfo lang = new LangInfo(wrapper, wrapper["language_name"]);

                    CurrentLanguage.langs.Add(lang);
                } catch (Exception)
                {
                    Debug.Log($"Can't handle {filename} language file.");
                    continue;
                }

            }
        }
    }
}

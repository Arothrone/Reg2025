using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;


[Serializable]
public class BgInfoScript
{
    public static Dictionary<int, BgInfoScript> backgrounds = new Dictionary<int, BgInfoScript>();
    public static int selectedId = 0;

    public static void LoadBackgrounds()
    {
        string path = Settings.bgPath;
        if (File.Exists(path))
        {
            string bgsJson = File.ReadAllText(path);
            
            List<BgInfoScript> wrapper = JsonConvert.DeserializeObject<List<BgInfoScript>>(bgsJson);
            foreach (BgInfoScript bg in wrapper)
            {
                if(bg.bgId == -1)
                {
                    Debug.Log("Background hadn't been loaded for some reason.");
                    continue;
                }
                bg.AddToBackgrounds();
            }
        }
        string pathId = Settings.bgIdPath;
        if (File.Exists(pathId))
        {
            string bgIdJson = File.ReadAllText(pathId);
            selectedId = JsonConvert.DeserializeObject<int>(bgIdJson);
        }
    }

    public static void SaveBackgrounds()
    {
        string json = JsonConvert.SerializeObject(backgrounds.Values);

        File.WriteAllText(Settings.bgPath, json);

        int bgIdRaw = selectedId;

        string jsonString = JsonConvert.SerializeObject(bgIdRaw);
        File.WriteAllText(Settings.bgIdPath, jsonString);
    }

    private void AddToBackgrounds()
    {
        if (backgrounds.ContainsKey(this.bgId))
        {
            Debug.Log("Background with same already id exists");
        } 
        else
        {
            backgrounds.Add(this.bgId, this);
        }
    }
    
    public BgInfoScript(int bgId_, bool bought_)
    {
        bgId = bgId_;
        bought = bought_;
        
    }

    [SerializeField] public int listOfTexturesIndex = 0;
    [SerializeField] public int bgId = -1;
    [SerializeField] public bool bought = false;
    [SerializeField] public string bgName = "Null"; // Only for convenience
}

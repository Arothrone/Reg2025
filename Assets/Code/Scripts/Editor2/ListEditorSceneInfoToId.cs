#nullable enable

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VectorGraphics.SVGParser;

public class ListEditorSceneInfoToId
{
    public List<EditorSceneInfoToId> list = new List<EditorSceneInfoToId>();



    public int GetListIndexById(int id)
    {
        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i].id == id)
            {
                return i;
            }
        }
        return -1;
    }


    public EditorSceneInfoToId? GetById(int id)
    {
        foreach (EditorSceneInfoToId editorSceneInfoToId in list)
        {
            if (editorSceneInfoToId.id == id)
            {
                return editorSceneInfoToId;
            }
        }
        return null;
    }

    private void Sort()
    {
        if (!list.Any()) return;
        list = list.OrderBy(item => item.id).ToList();
    }

    public EditorSceneInfoToId? Add(EditorSceneInfoToId scene)
    {
        if (scene == null) return null;

        

        if (scene.id < EditorSceneInfoToId.minId) return null;
        else if (scene.id >= list.Last().id)
        {
            scene.id = list.Last().id + 1;
            list.Add(scene);

        }
        else
        {
            int size = list.Count();
            for (int i = size - 1; i >= 0; i--)
            {
                if (list[i].id == scene.id)
                {
                    list[i].id = 1;

                    list.Insert(i, scene);
                    break;
                }
                else
                {
                    list[i].id += 1;
                }
            }
        }


        Save(scene);
        return scene;
    }

    public EditorSceneInfoToId? Add(EditorSceneInfo? sceneTp, int id)
    {
        if (sceneTp == null) return null;

        EditorSceneInfo scene = sceneTp.Value;

        return Add(new EditorSceneInfoToId(scene, id));
    }
    public EditorSceneInfoToId? Add(EditorSceneInfo? sceneTp)
    {
        if (sceneTp == null) return null;

        EditorSceneInfo scene = sceneTp.Value;

        EditorSceneInfoToId? added = null;
        if (list.Any()) {
            added = new EditorSceneInfoToId(scene, list.Last().id + 1);
            list.Add(added);
            Save(added);
        } else
        {
            added = new EditorSceneInfoToId(scene, EditorSceneInfoToId.minId);
            list.Add(added);
            Save(added);
        }
        return added;
    }

    public EditorSceneInfoToId? Replace(EditorSceneInfo? sceneInfoTp, int id)
    {
        if (sceneInfoTp == null) return null;
        EditorSceneInfo sceneInfo = sceneInfoTp.Value;


        if (id < EditorSceneInfoToId.minId) return null;
        EditorSceneInfoToId scene = new EditorSceneInfoToId(sceneInfo, id);
        if (id > list.Last().id)
        {
            scene.id = list.Last().id + 1;
            list.Add(scene);
        }
        else
        {
            int size = list.Count();
            for (int i = 0; i < size; i++)
            {
                if (list[i].id == id)
                {
                    DeleteSceneFile(list[i]);
                    list[i] = scene;
                }
            }
                    
            
        }
        Save(scene);

        return scene;
    }


    private void Normalize()
    {
        if (!list.Any()) return;

        Sort();

        int smallest = EditorSceneInfoToId.minId;

        for (int i = 0; i < list.Count; i++)
        {
            list[i].id = smallest + i;
        }
    }

    public void Delete(int id)
    {
        if (!list.Any()) return;
        

        if (id > list.Last().id || id < EditorSceneInfoToId.minId)
        {
            Debug.Log("Out of range");
            return;
        }
        int size = list.Count();
        for (int i = size - 1; i >= 0; i--)
        {
            if (list[i].id == id)
            {
                DeleteSceneFile(list[i]);
                list.RemoveAt(i);
                SaveLevelsToTags();
                return;
            } else
            {
                list[i].id -= 1;
            }
        }
    }



    private void DeleteSceneFile(EditorSceneInfo? sceneTp)
    {
        if (sceneTp == null) return;

        EditorSceneInfo scene = sceneTp.Value;

        string fileName = Path.Combine(Settings.editorScenesPath, scene.tag + ".json");
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        } else
        {
            Debug.Log("File " + fileName + " not found");
        }
    }

    private void DeleteSceneFile(EditorSceneInfoToId sceneAndId)
    {
        if (sceneAndId == null) return;

        DeleteSceneFile(sceneAndId.info);
    }


    public void Fill()
    {
        
        IEnumerable<string> files = Directory.EnumerateFiles(Settings.editorScenesPath);

        ListOfLevelsToTags? levelsToTagsTp = LoadLevelsToTags();

        if (levelsToTagsTp == null) return;

        ListOfLevelsToTags levelsToTags = levelsToTagsTp.Value;

        foreach (string file in files)
        {
            string filename = Path.GetFileName(file);
            if (filename.EndsWith(".json"))
            {
                try
                {
                    string jsonString = File.ReadAllText(file);

                    EditorSceneInfo scene = JsonUtility.FromJson<EditorSceneInfo>(jsonString);

                    

                    if (levelsToTags.levelTagToIds.Any())
                    {
                        bool isExistIn = false;
                        foreach (LevelTagToId lvlToId in levelsToTags.levelTagToIds)
                        {
                            if (scene.tag == lvlToId.tag)
                            {
                                list.Add(new EditorSceneInfoToId(scene, lvlToId.id));
                                isExistIn = true;
                                break;
                            }
                        }
                        if (!isExistIn)
                        {
                            File.Delete(file);
                        }
                    }

                    
                }
                catch (Exception)
                {
                    Debug.Log($"Can't handle {filename} editor save file.");
                    continue;
                }

            }
        }
        
        Normalize();
    }

    private void SaveLevelsToTags()
    {
        string path = Settings.editorScenesIndexPath;

        if (File.Exists(path))
        {
            ListOfLevelsToTags listOfTags = new ListOfLevelsToTags();

            if (listOfTags.levelTagToIds == null)
            {
                listOfTags.levelTagToIds = new List<LevelTagToId>();
            }


            foreach (EditorSceneInfoToId infoToId in list)
            {
                listOfTags.levelTagToIds.Add(new LevelTagToId(infoToId.info.tag, infoToId.id));
            }

            string json = JsonUtility.ToJson(listOfTags, true);

            try
            {
                File.WriteAllText(path, json);
                Debug.Log("Indeces saved to: " + path);
            }
            catch (IOException e)
            {
                Debug.LogError("Error saving game data: " + e.Message);
            }
        }
    }

    private ListOfLevelsToTags? LoadLevelsToTags()
    {
        string path = Settings.editorScenesIndexPath;

        if (File.Exists(path))
        {
            string lvlIds = File.ReadAllText(path);

            ListOfLevelsToTags wrapper = JsonUtility.FromJson<ListOfLevelsToTags>(lvlIds);

            return wrapper;
        }
        return null;
    }



    private void Save(EditorSceneInfo? sceneTp)
    {
        if (sceneTp == null) return;
        EditorSceneInfo scene = sceneTp.Value;

        string json = JsonUtility.ToJson(scene, true);

        string filePath = Path.Combine(Settings.editorScenesPath, scene.tag + ".json");
        if (File.Exists(filePath)) return;
        try
        {
            File.WriteAllText(filePath, json);
            Debug.Log("Level data saved to: " + filePath);
        }
        catch (IOException e)
        {
            Debug.LogError("Error saving game data: " + e.Message);
        }
        SaveLevelsToTags();
    }

    public void Save(EditorSceneInfoToId sceneAndId)
    {
        if (sceneAndId == null) return;

        Save(sceneAndId.info);
    }
}

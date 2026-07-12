using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using UnityEngine;
using static Unity.VectorGraphics.SVGParser;

static public class HandleEditorLogic
{
    public static List<GameObjectPrefabIndex> currentObjects = new List<GameObjectPrefabIndex>();
    public static ListOfGOScriptableObject prefabsList;
    public static ListEditorSceneInfoToId actualScenesToIds;
    public static LoadSlots loadSlots;
    public static EditorSceneInfoToId current = new EditorSceneInfoToId();



    static public EditorSceneInfo? GetCurrentSceneObject()
    {
        if (!currentObjects.Any()) return null;



        EditorSceneInfo listOfObjectInfo = new EditorSceneInfo();
        foreach (GameObjectPrefabIndex entry in currentObjects)
        {
            listOfObjectInfo.AddGameObjectToObjectInfoList(entry);
        }

        string tag = DateTime.Now.ToString("yyyyMMddHHmmssfff");

        listOfObjectInfo.tag = tag;

        listOfObjectInfo.carSettings = current.info.carSettings;

        return listOfObjectInfo;
    }

    static public void SaveAdd()
    {
        EditorSceneInfo? currentObjectTp = GetCurrentSceneObject();

        if (currentObjectTp == null) return;

        EditorSceneInfoToId newScene = actualScenesToIds.Add(currentObjectTp);

        if (loadSlots != null)
        {
            loadSlots.Reload();
        }

        Debug.Log(newScene);

        current = newScene;
    }

    static public void LoadScenesFrom()
    {
        actualScenesToIds = new ListEditorSceneInfoToId();
        actualScenesToIds.Fill();
    }

    static private void Load(EditorSceneInfoToId scene)
    {
        if (scene == null) return;



        if (prefabsList == null) return;
        if (currentObjects.Any())
        {
            foreach (GameObjectPrefabIndex GOPI in currentObjects)
            {
                UnityEngine.Object.Destroy(GOPI.GO);
            }
            currentObjects.Clear();
        }
        
        foreach (ObjectInfo obj in scene.info.objectInfoList)
        {
            GameObject spawnedGO = UnityEngine.Object.Instantiate(prefabsList.listOfGO[obj.prefabIndex]);
            spawnedGO.transform.position = obj.position;
            spawnedGO.transform.rotation = obj.rotation;
            currentObjects.Add(new GameObjectPrefabIndex(spawnedGO, obj.prefabIndex));
        }

        current = scene;

    }

    static public void Load(int sceneId)
    {
        Load(actualScenesToIds.GetById(sceneId));
    }

    static public void LoadByListIndex(int ind)
    {
        Load(actualScenesToIds.list[ind]);
    }


    static public void DeleteScene(int sceneId)
    {
        actualScenesToIds.Delete(sceneId);
        if (loadSlots != null)
        {
            loadSlots.Reload();
        }
        if (sceneId == current.id) current = new EditorSceneInfoToId();
    }

    static public void SaveTo(EditorSceneInfo sceneInfo, int sceneId)
    {
        EditorSceneInfoToId newScene = actualScenesToIds.Replace(sceneInfo, sceneId);
        if (newScene == null) return;

        current = newScene;
    }

    static public void SaveTo(int sceneId)
    {
        EditorSceneInfo? tp = GetCurrentSceneObject();
        if (tp == null) return;
        SaveTo(tp.Value, sceneId);
    }

    static public void SaveTo(int oldSceneId, int newSceneId)
    {
        EditorSceneInfo? tp = actualScenesToIds.GetById(oldSceneId).info;
        if (tp == null) return;
        SaveTo(tp.Value, newSceneId);
    }
}

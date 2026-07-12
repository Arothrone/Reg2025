using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct EditorSceneInfo
{
    public EditorSceneInfo(List<ObjectInfo> list = null, string tg = "", CarSettings car = new CarSettings())
    {
        objectInfoList = list ?? new List<ObjectInfo>();
        tag = tg;
        carSettings = car;

    }
    public List<ObjectInfo> objectInfoList;
    public string tag;

    public CarSettings carSettings;


    public void AddGameObjectToObjectInfoList(GameObject GOToAdd, int prefabIndex)
    {
        if (objectInfoList == null) objectInfoList = new List<ObjectInfo>();
        objectInfoList.Add(new ObjectInfo(GOToAdd, prefabIndex));
    }

    public void AddGameObjectToObjectInfoList(GameObjectPrefabIndex GOPI)
    {
        AddGameObjectToObjectInfoList(GOPI.GO, GOPI.index);
    }
}

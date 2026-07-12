using System;
using UnityEngine;

[Serializable]
public struct ObjectInfo
{
    public ObjectInfo(GameObject go, int index)
    {
        position = go.transform.position;
        rotation = go.transform.rotation;
        prefabIndex = index;
    }

    public ObjectInfo(GameObjectPrefabIndex GOPI)
    {
        position = GOPI.GO.transform.position;
        rotation = GOPI.GO.transform.rotation;
        prefabIndex = GOPI.index;
    }
    public Vector3 position;
    public Quaternion rotation;
    public int prefabIndex;
}

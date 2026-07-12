using UnityEngine;

public struct GameObjectPrefabIndex
{
    public GameObjectPrefabIndex(GameObject go, int ind)
    {
        GO = go;
        index = ind;
    }
    public GameObject GO;
    public int index;
}

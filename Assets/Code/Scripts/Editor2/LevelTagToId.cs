using System;
using UnityEngine;

[Serializable]
public struct LevelTagToId
{
    public LevelTagToId(string tg = "", int i = -1)
    {
        tag = tg;
        id = i;
    }

    public string tag;
    public int id;
}

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ListOfLevelsToTags
{
    public ListOfLevelsToTags(List<LevelTagToId> lst = null)
    {
        levelTagToIds = lst ?? new List<LevelTagToId>();
    }

    public List<LevelTagToId> levelTagToIds;
}

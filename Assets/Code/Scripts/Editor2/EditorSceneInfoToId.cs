using UnityEngine;

public class EditorSceneInfoToId
{
    public static int minId = 1;
    public EditorSceneInfoToId(EditorSceneInfo inf = new EditorSceneInfo(), int i = 1)
    {
        info = inf;
        id = i;
    }

    public EditorSceneInfo info = new EditorSceneInfo();
    public int id = minId;
}

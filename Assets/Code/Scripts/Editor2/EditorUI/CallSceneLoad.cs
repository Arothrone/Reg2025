using UnityEngine;

public class CallSceneLoad : MonoBehaviour
{
    public void Save()
    {
        
    }

    public void Load(string submittedText)
    {
        int i = int.Parse(submittedText);

        HandleEditorLogic.Load(i);
    }

    public void Delete(string submittedText)
    {
        int i = int.Parse(submittedText);

        HandleEditorLogic.DeleteScene(i);
    }
}

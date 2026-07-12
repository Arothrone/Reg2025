using UnityEngine;

public class ReloadLevelEditor : MonoBehaviour
{
    
    public void ReloadLevel()
    {
        if (GameEditorMainLogic.gameStarter == null) return;

        if (ChangeLevelValueEditor.currentLevelValue <= -1) return;
    
        HandleEditorLogic.LoadByListIndex(ChangeLevelValueEditor.currentLevelValue);
        GameEditorMainLogic.gameStarter.Set();

    }
}

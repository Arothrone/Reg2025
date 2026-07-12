using UnityEngine;

public class NextLevelEditor : MonoBehaviour
{
    
    public void GoToNextLevel()
    {
        if (GameEditorMainLogic.gameStarter == null) return;
        if (ChangeLevelValueEditor.currentLevelValue <= -1) return;

        ChangeLevelValueEditor.currentLevelValue++;

        if (ChangeLevelValueEditor.currentLevelValue >= HandleEditorLogic.actualScenesToIds.list.Count)
        {
            ChangeLevelValueEditor.currentLevelValue = 0;
        }

        HandleEditorLogic.LoadByListIndex(ChangeLevelValueEditor.currentLevelValue);
        GameEditorMainLogic.gameStarter.Set();
    }


}

using UnityEngine;

public class ButtonsLogic : MonoBehaviour
{
    public void OnRemoveButton()
    {
        if (LevelSlot.selected == null) return;
        HandleEditorLogic.DeleteScene(LevelSlot.selected.idOfScene);
    }

    public void OnAddButton()
    {
        HandleEditorLogic.SaveAdd();
    }

    public void OnSaveButton()
    {
        if (LevelSlot.selected == null) return;

        Debug.Log(LevelSlot.selected.idOfScene);
        HandleEditorLogic.SaveTo(LevelSlot.selected.idOfScene);
    }

    public void OnLoadButton()
    {
        if (LevelSlot.selected == null) return;
        HandleEditorLogic.Load(LevelSlot.selected.idOfScene);
    }
}

using UnityEngine;

public class LoadSlots : MonoBehaviour
{
    [SerializeField] Transform whereToLoad;
    [SerializeField] GameObject slotPrefab;

    private void Start()
    {
        HandleEditorLogic.loadSlots = this;
        LevelSlot.selected = null;
        LoadAll();
    }

    private void LoadAll()
    {
        foreach (EditorSceneInfoToId sceneAndId in HandleEditorLogic.actualScenesToIds.list)
        {
            Create(sceneAndId);
        }
    }

    public void Reload()
    {
        LevelSlot.selected = null;
        foreach (Transform child in whereToLoad)
        {
            Destroy(child.gameObject);
        }

        LoadAll();
    }

    public void Create(EditorSceneInfoToId sceneAndId)
    {
        GameObject ins = Instantiate(slotPrefab, whereToLoad);
        LevelSlot slot = ins.GetComponent<LevelSlot>();
        slot.idOfScene = sceneAndId.id;
        slot.SetText();
    }
}

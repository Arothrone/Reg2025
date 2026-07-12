using TMPro;
using UnityEngine;

public class LevelSlot : MonoBehaviour
{
    public static LevelSlot selected = null;
    [SerializeField] private GameObject selectedGO = null;
    [SerializeField] TMP_Text levelText;

    [HideInInspector] public int idOfScene = 0;

    [HideInInspector] public bool isSelected = false;
    

    private void Start()
    {
        SetText();
    }
    public void SetText()
    {
        levelText.text = idOfScene.ToString();
    }

    private void Deselect()
    {
        isSelected = false;
        if (selectedGO != null)
        {
            selectedGO.SetActive(false);
        }
    }

    public void OnSlotClick()
    {
        if (selected != null)
        {
            selected.Deselect();
        }
        if (selectedGO != null)
        {
            selectedGO.SetActive(true);
        }
        isSelected = true;
        selected = this;
    }
}

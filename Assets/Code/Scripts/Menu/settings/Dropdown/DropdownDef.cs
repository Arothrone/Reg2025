using TMPro;
using UnityEngine;

public abstract class DropdownDef : MonoBehaviour
{
    [SerializeField] protected TMP_Dropdown dropdownGO;
    void OnEnable()
    {
        PreSetValues();
    }

    virtual protected void ChangeDropdownValue()
    {
        
    }

    private void PreSetValues()
    {
        dropdownGO.ClearOptions();
        SetValues();
    }

    virtual public void SetValues()
    {
        
    }

    virtual public void Action()
    {
        
    }

    static public void UpdateValue()
    {
        DropdownDef[] myScripts = FindObjectsByType<DropdownDef>(FindObjectsSortMode.None);

        foreach (DropdownDef script in myScripts)
        {
            script.ChangeDropdownValue();
        }
    }
}

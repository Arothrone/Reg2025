using UnityEngine;

public abstract class ToggleScript : MonoBehaviour
{

    [SerializeField] GameObject ONGO;
    [SerializeField] GameObject OFFGO;

    void OnEnable()
    {
        
        UpdateToggle();
    }

    public void ChangeState()
    {
        turned = !turned;

        ONGO.SetActive(turned);
        OFFGO.SetActive(!turned);

        Action();

    }


    virtual protected void ChangeTurnedValUpd()
    {
        
    }



    public void UpdateToggle()
    {
        
        ChangeTurnedValUpd();
        ONGO.SetActive(turned);
        OFFGO.SetActive(!turned);
    }

    virtual public void Action()
    {
        
    }

    public static void UpdateToggles()
    {
        ToggleScript[] myScripts = FindObjectsByType<ToggleScript>(FindObjectsSortMode.None);

        foreach (ToggleScript script in myScripts)
        {
            script.UpdateToggle();
        }
    }

    protected bool turned = false;
}

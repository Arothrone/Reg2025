using UnityEngine;

public class bgMenuObjectScript : MonoBehaviour
{
    [SerializeField] int thisGOBgId;
    [SerializeField] uint cost;
    [SerializeField] GameObject blockGO;
    [SerializeField] GameObject selectedGO;

    [SerializeField] ListOfGO listOfSelected;

    private BgInfoScript bgInfo;


    void Start()
    {
        bgInfo = BgInfoScript.backgrounds[thisGOBgId];
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        blockGO.SetActive(!bgInfo.bought);

        if (thisGOBgId == BgInfoScript.selectedId)
        {
            foreach (GameObject selected in listOfSelected.listOfGo)
            {
                selected.SetActive(false);
            }
            selectedGO.SetActive(true);
        }
    }

    public void OnClick()
    {
        if (bgInfo.bought)
        {
            BgInfoScript.selectedId = thisGOBgId;
            UpdateStatus();
            BgInfoScript.SaveBackgrounds();
        } else {
            bool isBought = CashScript.Subtract(cost);

            if (isBought)
            {
                bgInfo.bought = true;
                BgInfoScript.selectedId = thisGOBgId;
                UpdateStatus();
                BgInfoScript.SaveBackgrounds();
            }
        }
    }
}

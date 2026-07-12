using UnityEngine;

public class HideAllShowOne : MonoBehaviour
{

    [SerializeField] GameObject selected;
    [SerializeField] ListOfGO listOfGO;

    public void Select()
    {
        
        selected.SetActive(true);
        foreach(GameObject GO in listOfGO.listOfGo)
        {
            if (GO != selected)
            {
                GO.SetActive(false);
            }
        }
    }

    public void SelectByIndex(int ind)
    {
        for (int i = 0; i < listOfGO.listOfGo.Count; i++)
        {
            GameObject GO = listOfGO.listOfGo[i];
            
            if (i == ind)
            {
                GO.SetActive(true);
            }
            else
            {
                GO.SetActive(false);
            }
        }
    }

    public void SelectShow()
    {
        selected.SetActive(true);
    }
}

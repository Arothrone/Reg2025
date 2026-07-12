using UnityEngine;

public class HideShowGO : MonoBehaviour
{
    [SerializeField] GameObject GO;

    public void Show()
    {
        GO.SetActive(true);
    }

    public void Hide()
    {
        GO.SetActive(false);
    }
}

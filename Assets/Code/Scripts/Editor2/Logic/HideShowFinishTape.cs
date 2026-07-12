using UnityEngine;

public class HideShowFinishTape : MonoBehaviour
{
    [SerializeField] GameObject finishTape;

    public void Show(bool show)
    {
        finishTape.SetActive(show);
    }
}

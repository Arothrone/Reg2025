using UnityEngine;

public class CloseEditorMenues : MonoBehaviour
{
    [SerializeField] GameObject menu1;
    [SerializeField] GameObject menu2;

    public void OnPress()
    {
        menu1.SetActive(false);
        menu2.SetActive(false);
    }
}

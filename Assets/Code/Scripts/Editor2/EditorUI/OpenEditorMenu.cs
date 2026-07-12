using UnityEngine;

public class OpenEditorMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;

    public void OnPress()
    {
        menu.SetActive(true);
    }
}

using UnityEngine;

public class WinPanelLogic : MonoBehaviour
{
    [SerializeField] WinDefeatGOScriptableObject panelsSO;

    [SerializeField] PlaySoundOneSource sound;

    void Awake()
    {
        panelsSO.winPanelGO = gameObject;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {

        if (sound != null)
        {
            sound.PlaySound();
        }
    }
}

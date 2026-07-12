using Unity.VisualScripting;
using UnityEngine;

public class DefeatPanelLogic2 : MonoBehaviour
{
    [SerializeField] WinDefeatGOScriptableObject panelsSO;

    [SerializeField] PlaySoundOneSource sound;


    void Awake()
    {
        panelsSO.defeatPanelGO = gameObject;
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

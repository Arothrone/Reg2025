using UnityEngine;
using UnityEngine.EventSystems;

public class SlotLogicMain : MonoBehaviour, IPointerDownHandler, IDropHandler
{

    [SerializeField] PlaySoundOneSource sound;

    public GameObject GOTospawnIn;
    public void OnPointerDown(PointerEventData eventData)
    {
        RunInstantiate();
    }
    public void OnDrop(PointerEventData eventData)
    {
        RunInstantiate();
    }
    private void RunInstantiate()
    {
        foreach (Transform child in GOTospawnIn.transform)
        {
            Destroy(child.gameObject);
        }
        Instantiate(Choosen.selectedUpgrade.objectToSpawn, GOTospawnIn.transform);

        if (sound != null)
        {
            sound.PlaySound();
        }

        Choosen.selectedUpgrade.Delete();
    }
}

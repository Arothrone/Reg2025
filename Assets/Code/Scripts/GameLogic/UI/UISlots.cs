using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(50)]

public class UISlots : MonoBehaviour
{
    [SerializeField] GameObject objectsBox;
    [SerializeField] SlotList slotList;
    public List<GameObject> upgradeChoosableObjects;

    void Start()
    {
        Set();
    }

    private void Set()
    {
        if (Choosen.slotList != null)
        {
            Choosen.slotList.DestroyAll();
        }
        foreach(Transform child in objectsBox.transform)
        {
            Destroy(child.gameObject);
        }
        Choosen.slotList = slotList;
        Choosen.slotList.Set();

        Choosen.slotList.SetActiveSlots(false, false, false, false);

        foreach(GameObject go in upgradeChoosableObjects)
        {
            Instantiate(go, objectsBox.transform);
        }
    }

    public void Reset2()
    {
        Set();
    }
}

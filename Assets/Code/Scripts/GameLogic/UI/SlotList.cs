using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(45)]

public class SlotList : MonoBehaviour
{
    [HideInInspector] public GameObject wheelSlot1;
    [HideInInspector] public GameObject wheelSlot2;
    [HideInInspector] public GameObject propellerSlot;
    [HideInInspector] public GameObject wingSlot;
    [SerializeField] CarScriptableObject Car;
    List<SlotLogicMain> slotsToDelIn;


    public void Set()
    {
        wheelSlot1 = Car.wheelSlot1;
        wheelSlot2 = Car.wheelSlot2;
        propellerSlot = Car.propellerSlot;
        wingSlot = Car.wingSlot;
        slotsToDelIn = new List<SlotLogicMain> {wheelSlot1.GetComponent<SlotLogicMain>(),
            wheelSlot2.GetComponent<SlotLogicMain>(),
            propellerSlot.GetComponent<SlotLogicMain>(),
            wingSlot.GetComponent<SlotLogicMain>()};
    }

    private void OnEnable()
    {
        Set();
    }

    public void SetActiveSlots(bool s1, bool s2, bool s3, bool s4)
    {
        wheelSlot1.SetActive(s1);
        wheelSlot2.SetActive(s2);
        propellerSlot.SetActive(s3);
        wingSlot.SetActive(s4);

    }

    public void DestroyAll()
    {
        foreach (SlotLogicMain s in slotsToDelIn)
        {
            foreach (Transform child in s.GOTospawnIn.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}

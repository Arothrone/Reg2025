using UnityEngine;

[DefaultExecutionOrder(-100)]
public class OnCarEnable : MonoBehaviour
{
    [SerializeField] CarScriptableObject carRef;
    [SerializeField] GameObject CurrentCar;
    [SerializeField] GameObject wheelSlot1;
    [SerializeField] GameObject wheelSlot2;
    [SerializeField] GameObject propellerSlot;
    [SerializeField] GameObject wingSlot;


    private void Set()
    {
        carRef.CurrentCar = CurrentCar;
        carRef.wheelSlot1 = wheelSlot1;
        carRef.wheelSlot2 = wheelSlot2;
        carRef.propellerSlot = propellerSlot;
        carRef.wingSlot = wingSlot;
    }

    private void OnEnable()
    {
        Set();
    }

    private void Awake()
    {
        Set();
    }
}

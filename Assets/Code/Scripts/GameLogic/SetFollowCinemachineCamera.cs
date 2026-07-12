using Unity.Cinemachine;
using UnityEngine;

public class SetFollowCinemachineCamera : MonoBehaviour
{
    [SerializeField] CarScriptableObject Car;
    void OnEnable()
    {
        GetComponent<CinemachineCamera>().Follow = Car.CurrentCar.transform;
    }
}

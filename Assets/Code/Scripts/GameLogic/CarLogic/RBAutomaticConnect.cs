using UnityEngine;

public class RBAutomaticConnect : MonoBehaviour
{
    [SerializeField] CarScriptableObject Car;
    void Start()
    {
        GameObject carGO = Car.CurrentCar;
        Joint2D joint = GetComponent<Joint2D>();

        joint.connectedBody = carGO.GetComponent<Rigidbody2D>();
    }
}

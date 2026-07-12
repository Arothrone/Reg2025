using UnityEngine;

public class TuneWheelAnchorPosition : MonoBehaviour
{
    private WheelJoint2D joint;
    private GameObject carGO;
    [SerializeField] CarScriptableObject Car;
    void Start()
    {
        carGO = Car.CurrentCar;
        joint = GetComponent<WheelJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = ConvertLocalPosAToLocalPosB(transform, carGO.transform, Vector2.zero);
    }

    private Vector3 ConvertLocalPosAToLocalPosB(Transform transformA, Transform transformB, Vector3 localPositionA)
    {

        Vector3 worldPosition = transformA.TransformPoint(localPositionA);

        Vector3 localPositionB = transformB.InverseTransformPoint(worldPosition);

        return localPositionB;
    }
}
// Why script?????
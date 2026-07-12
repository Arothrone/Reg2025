using UnityEngine;

public class SetupWheelJoint : MonoBehaviour
{
    private WheelJoint2D joint;
    private GameObject carGO;
    [SerializeField] CarScriptableObject Car;

    void Start()
    {
        carGO = Car.CurrentCar;
        joint = GetComponent<WheelJoint2D>();
        //joint.autoConfigureConnectedAnchor = false;
        joint.anchor =  ConvertLocalPosAToLocalPosB(transform, carGO.transform, Vector2.zero);
        joint.connectedAnchor = Vector2.zero;
        WheelJoint2D newJoint = carGO.AddComponent<WheelJoint2D>();

        newJoint.anchor = joint.anchor;
        newJoint.connectedAnchor = joint.connectedAnchor;
        newJoint.connectedBody = GetComponent<Rigidbody2D>();
        newJoint.autoConfigureConnectedAnchor = joint.autoConfigureConnectedAnchor;
        newJoint.enableCollision = joint.enableCollision;
        newJoint.useMotor = joint.useMotor;

        JointSuspension2D newJointSuspension = newJoint.suspension;
        newJointSuspension.dampingRatio = joint.suspension.dampingRatio;
        newJointSuspension.frequency = joint.suspension.frequency;
        newJoint.suspension = newJointSuspension;

        JointMotor2D newJointMotor = newJoint.motor;
        newJointMotor.motorSpeed = joint.motor.motorSpeed;
        newJointMotor.maxMotorTorque = joint.motor.maxMotorTorque;
        newJoint.motor = newJointMotor;

        Destroy(joint);
    }

    private Vector3 ConvertLocalPosAToLocalPosB(Transform transformA, Transform transformB, Vector3 localPositionA)
    {

        Vector3 worldPosition = transformA.TransformPoint(localPositionA);

        Vector3 localPositionB = transformB.InverseTransformPoint(worldPosition);

        return localPositionB;
    }
}

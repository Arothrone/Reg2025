using UnityEngine;
using UnityEngine.InputSystem;

public class DevObjectMoveScript : MonoBehaviour
{
    [SerializeField] float sensitivity = 5;
    [SerializeField] float moveSpeed = 5;
    InputAction moveAction;
    InputAction upDownAction;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        moveAction = InputSystem.actions.FindAction("Move");
        upDownAction = InputSystem.actions.FindAction("UpDown");
    }
    void Update()
    {
        float upDownValue = upDownAction.ReadValue<float>();

        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector2 lookValue = Pointer.current.delta.value*Time.deltaTime*sensitivity;

        transform.Rotate(Vector3.up * lookValue.x, Space.World);

        transform.Rotate(Vector3.right * -lookValue.y, Space.Self);

        transform.Translate(new Vector3(moveValue.x, upDownValue, moveValue.y) * Time.deltaTime * moveSpeed);
    }
}

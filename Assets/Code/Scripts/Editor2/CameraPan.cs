using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CameraPan : MonoBehaviour
{
    static public bool isDragging = false;
    static public bool isHovering = false;

    InputAction clickAction;

    [SerializeField] float speed;
    [SerializeField] float distanceFromCamera = -1;

    Vector3 prevPos;
    Vector3 curPos;

    [SerializeField] Transform upperLimitTransform;
    [SerializeField] Transform lowerLimitTransform;
    [SerializeField] Transform rightLimitTransform;
    [SerializeField] Transform leftLimitTransform;

    
    private void Start()
    {
        clickAction = InputSystem.actions.FindAction("Click");
        prevPos = Mouse.current.position.ReadValue();
        curPos = prevPos;


        if (distanceFromCamera < 0)
        {
            distanceFromCamera = Math.Abs(Camera.main.transform.position.z);
        }
    }

    private void RemoveClickSelection(Vector3 delta)
    {
        if (delta != Vector3.zero)
        {
            if (InteractWithUIObjects.selected != null && InteractWithUIObjects.selected.isSelectedByClick)
            {
                InteractWithUIObjects.selected.Deselect();
            }
        }
    }

    private void LateUpdate()
    {
        curPos = Mouse.current.position.ReadValue();
        if (clickAction.IsPressed() && !isDragging && !isHovering && !DragObjectOnScene.isDragging)
        {
            prevPos.z = distanceFromCamera;

            Vector3 prevPosWorld = Camera.main.ScreenToWorldPoint(prevPos);

            curPos.z = distanceFromCamera;

            Vector3 curPosWorld = Camera.main.ScreenToWorldPoint(curPos);

            Vector3 delta = prevPosWorld - curPosWorld;

            Vector3 newPos = transform.position + delta;

            if (newPos.y < upperLimitTransform.position.y && newPos.y > lowerLimitTransform.position.y &&
                newPos.x > leftLimitTransform.position.x && newPos.x < rightLimitTransform.position.x) transform.position = newPos;

            RemoveClickSelection(delta);

        }
        prevPos = curPos;
    }
}

using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class RotateLastObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] float rotationSpeed = 5f;
    private bool holding;
    InputAction rotateAction;

    private void Start()
    {
        rotateAction = InputSystem.actions.FindAction("Rotate");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        holding = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        holding = false;
    }



    private void Update()
    {
        if (holding || rotateAction.IsPressed())
        {
            
            if (HandleEditorLogic.currentObjects.Any())
            {
                GameObject lastPlacedGO = HandleEditorLogic.currentObjects.Last().GO;

                lastPlacedGO.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }
        }
    }

}

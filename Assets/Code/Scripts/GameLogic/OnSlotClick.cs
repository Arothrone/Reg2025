using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class OnSlotClick : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("Clicked!");
    }
    void Update()
    {
        // if (InputSystem.actions.FindAction("Click").ReadValue<float>() == 1)
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            
        //     if (Physics.Raycast(ray, out RaycastHit hit))
        //     {
        //         Debug.Log("Hit object: " + hit.transform.gameObject.name);
        //     }
        // }
    }
}

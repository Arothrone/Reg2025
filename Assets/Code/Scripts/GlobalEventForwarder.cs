using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GlobalEventForwarder : MonoBehaviour, IDropHandler, IPointerDownHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        ForwardEvent<IDropHandler>(eventData, ExecuteEvents.dropHandler);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ForwardEvent<IPointerDownHandler>(eventData, ExecuteEvents.pointerDownHandler);
    }

    private void ForwardEvent<T>(PointerEventData eventData, ExecuteEvents.EventFunction<T> function) where T : IEventSystemHandler
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (RaycastResult hit in results)
        {
            if (hit.gameObject == gameObject) continue;
            ExecuteEvents.ExecuteHierarchy(hit.gameObject, eventData, function);
        }
    }
}

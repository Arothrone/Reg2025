using UnityEngine;
using UnityEngine.EventSystems;

public class BlockCameraMovementOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        CameraPan.isHovering = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        CameraPan.isHovering = false;
    }
}

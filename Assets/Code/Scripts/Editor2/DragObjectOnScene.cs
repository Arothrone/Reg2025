using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DragObjectOnScene : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private static DragObjectOnScene selected = null;
    private bool isSelected = false;
    public static bool isDragging = false;
    [SerializeField] float distanceFromCamera = -1;

    

    private void Start()
    {
        if (distanceFromCamera < 0)
        {
            distanceFromCamera = Math.Abs(Camera.main.transform.position.z);
        }
    }

    public void Deselect()
    {

        isSelected = false;
        selected = null;
    }

    public void Select()
    {
        if (!HandleEditorLogic.currentObjects.Any() || isDragging) return;
        if (selected != null)
        {
            selected.Deselect();
        }

        isSelected = true;
        selected = this;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        if (this == selected && isSelected)
        {
            for (int i = 0; i < HandleEditorLogic.currentObjects.Count; ++i)
            {
                GameObjectPrefabIndex temp = HandleEditorLogic.currentObjects[i];

                if (temp.GO == gameObject)
                {
                    HandleEditorLogic.currentObjects.RemoveAt(i);
                    HandleEditorLogic.currentObjects.Add(temp);
                }
            }
            isDragging = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector3 mousePosToObject = Mouse.current.position.ReadValue();

            mousePosToObject.z = distanceFromCamera;

            Vector3 worldPointToObject = Camera.main.ScreenToWorldPoint(mousePosToObject);

            transform.position = worldPointToObject;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            isDragging = false;
            Deselect();
        }
        
    }

    void LateUpdate()
    {

        if (Pointer.current.press.wasReleasedThisFrame) {
            Vector3 curMousePos = Mouse.current.position.ReadValue();

            curMousePos.z = distanceFromCamera;

            Vector2 mouseWorldPoint = Camera.main.ScreenToWorldPoint(curMousePos);

            Collider2D hitCollider = Physics2D.OverlapPoint(mouseWorldPoint);

            if (hitCollider == GetComponent<Collider2D>())
            {
                if (this == selected && isSelected)
                {

                    
                }
                else
                {
                    Select();
                }
            } else
            {
                isSelected = false;
            }
        }
    }
}

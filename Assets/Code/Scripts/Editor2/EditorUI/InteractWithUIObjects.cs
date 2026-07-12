using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InteractWithUIObjects : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler
{

    public static InteractWithUIObjects selected;

    [SerializeField] float distanceFromCamera = -1;

    [SerializeField] GameObject selectBox;

    [SerializeField] RectTransform boundsObject;

    private ScrollRect parentScrollRect;

    private Canvas canvas;
    private CanvasGroup canvasGroup;
    [SerializeField] GameObject ObjectToDrag;

    [SerializeField] ListOfGOScriptableObject listOfPrefabsToSpawn;
    [SerializeField] int indexOfPrefab;
    private GameObject spawnedGO = null;

    public bool isSelectedByClick = false;




    private void Start()
    {
        HandleEditorLogic.prefabsList = listOfPrefabsToSpawn;

        if (distanceFromCamera < 0)
        {
            distanceFromCamera = Math.Abs(Camera.main.transform.position.z);
        }
    }

    private void Awake()
    {
        canvasGroup = ObjectToDrag.GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();

        parentScrollRect = GetComponentInParent<ScrollRect>();

    }


    public void Deselect()
    {
        if (selectBox != null)
        {
            selectBox.SetActive(false);
        }
        isSelectedByClick = false;
        selected = null;
    }

    public void Select()
    {
        if (selected != null)
        {
            selected.Deselect();
        }

        if (selectBox != null)
        {

            selectBox.SetActive(true);
            
        }
        isSelectedByClick = true;
        selected = this;
    }

    public void Delete()
    {
        Deselect();
        Destroy(gameObject);
    }




    public void OnBeginDrag(PointerEventData eventData)
    {
        isSelectedByClick = false;
        if (parentScrollRect != null) parentScrollRect.OnBeginDrag(eventData);

        CameraPan.isDragging = true;


        Select();
        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (parentScrollRect != null) parentScrollRect.OnDrag(eventData);

        Vector3 mousePosition = eventData.position;
        mousePosition.z = canvas.planeDistance;
        Vector3 worldPoint = canvas.worldCamera.ScreenToWorldPoint(mousePosition);
        if (!RectTransformUtility.RectangleContainsScreenPoint(boundsObject, mousePosition, canvas.worldCamera))
        {
            if (spawnedGO == null)
            {
                spawnedGO = Instantiate(listOfPrefabsToSpawn.listOfGO[indexOfPrefab], Vector3.zero, Quaternion.identity);
            }

            Vector3 mousePosToObject = Mouse.current.position.ReadValue();

            mousePosToObject.z = distanceFromCamera;

            Vector3 worldPointToObject = Camera.main.ScreenToWorldPoint(mousePosToObject);

            spawnedGO.transform.position = worldPointToObject;
            
        }
        else
        {
            if (spawnedGO != null)
            {
                Destroy(spawnedGO);
                spawnedGO = null;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (parentScrollRect != null) parentScrollRect.OnEndDrag(eventData);

        Deselect();
        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = true;
        }

        
        CameraPan.isDragging = false;

        HandleEditorLogic.currentObjects.Add(new GameObjectPrefabIndex(spawnedGO, indexOfPrefab));
        spawnedGO = null;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Select();
    }

    private void Update()
    {

        if (isSelectedByClick && Pointer.current.press.wasReleasedThisFrame && !RectTransformUtility.RectangleContainsScreenPoint(boundsObject, Mouse.current.position.ReadValue(), canvas.worldCamera))
        {
            
            Vector3 mousePosToObject = Mouse.current.position.ReadValue();

            mousePosToObject.z = distanceFromCamera;

            Vector3 worldPointToObject = Camera.main.ScreenToWorldPoint(mousePosToObject);

            HandleEditorLogic.currentObjects.Add(new GameObjectPrefabIndex(
                Instantiate(listOfPrefabsToSpawn.listOfGO[indexOfPrefab], worldPointToObject, Quaternion.identity), indexOfPrefab));
            Deselect();
        }
    }
}

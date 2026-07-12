using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Upgrade : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] GameObject selectBox;
    [SerializeField] bool wheelSlot1Check;
    [SerializeField] bool wheelSlot2Check;
    [SerializeField] bool propellerSlotCheck;
    [SerializeField] bool wingSlotCheck;
    public GameObject objectToSpawn;


    private Transform transformToDrag;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    [SerializeField] GameObject ObjectToDrag;
    bool toMove = false;
    [SerializeField] float flySpeed = 5f;

    private Vector3 startPosition;


    public void SelectSlotUI()
    {
        if (Choosen.selectedUpgrade != null)
        {
            Choosen.selectedUpgrade.Deselect();
        }
        Select();
    }

    public void Deselect()
    {
        if (selectBox != null)
        {
            selectBox.SetActive(false);
            Choosen.selectedUpgrade = null;
            Choosen.slotList.SetActiveSlots(false, false, false, false);
        }
    }

    public void Select()
    {
        if (selectBox != null)
        {
            Choosen.slotList.SetActiveSlots(wheelSlot1Check, wheelSlot2Check, propellerSlotCheck, wingSlotCheck);
            Choosen.selectedUpgrade = this;
            selectBox.SetActive(true);
        }
    }

    public void Delete()
    {
        Deselect();
        Destroy(gameObject);
    }



    private void Awake()
    {
        transformToDrag = ObjectToDrag.GetComponent<Transform>();
        canvasGroup = ObjectToDrag.GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!toMove)
        {
            startPosition = transformToDrag.position;
        } else
        {
            toMove = false;
        }


        SelectSlotUI();
        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = eventData.position;
        mousePosition.z = canvas.planeDistance;
        Vector3 worldPoint = canvas.worldCamera.ScreenToWorldPoint(mousePosition);

        transformToDrag.position = new Vector3(worldPoint.x, worldPoint.y, transformToDrag.position.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Deselect();
        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = true;
        }
        toMove = true;
    }

    private void Update()
    {
        if (toMove)
        {
            float step = flySpeed * Time.deltaTime;



            transformToDrag.position = Vector3.MoveTowards(
                transformToDrag.position,
                startPosition,
                step
            );

            if (Vector3.Distance(transformToDrag.position, startPosition) < 0.01f)
            {
                transformToDrag.position = startPosition;
                toMove = false;
            }
        }
    }
}

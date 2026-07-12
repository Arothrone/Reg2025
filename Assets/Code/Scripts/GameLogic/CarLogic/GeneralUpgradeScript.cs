using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GeneralUpgradeScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] CarScriptableObject Car;
    protected GameObject carGO;
    protected Rigidbody2D carRB;
    public void OnPointerDown(PointerEventData eventData)
    {
        OnClick();
    }

    private void Awake()
    {
        carGO = Car.CurrentCar;
        carRB = carGO.GetComponent<Rigidbody2D>();
    }

    protected virtual void OnClick()
    {

    }
}

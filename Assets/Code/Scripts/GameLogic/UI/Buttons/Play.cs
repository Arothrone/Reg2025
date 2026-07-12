using UnityEngine;

public class Play : MonoBehaviour
{
    [SerializeField] GameObject mainCanvasGOToHide;
    [SerializeField] GameObject resetButtonToShow;
    private GameObject car;
    private Rigidbody2D carRB;
    [SerializeField] CarScriptableObject Car;


    private void Set()
    {
        car = Car.CurrentCar;
        carRB = car.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Set();
    }
    public void OnPlayButtonPressed()
    {
        Set();
        mainCanvasGOToHide.SetActive(false);
        resetButtonToShow.SetActive(true);
        carRB.bodyType = RigidbodyType2D.Dynamic;
        carRB.interpolation = RigidbodyInterpolation2D.Interpolate;
        RocketScriptStart.isGameStarted = true;
    }
}

using System.Collections;
using UnityEngine;

public class TempCoinThrow : MonoBehaviour
{
    [SerializeField] float throwForce = 4f;
    [SerializeField] float flySpeed = 5f;
    [SerializeField] float gravityScale = 5f;

    [SerializeField] float deleteNearDistance = 10;
    [SerializeField] float FlyTimeVal = 1;
    private Rigidbody2D rb;
    private bool toMove = false;


    [HideInInspector] public Transform targetTransform;
    Vector3 newPos;

    private float measureValue;

    [SerializeField] PlaySoundOneSource sound;

    void Start()
    {
        measureValue = GetWorldDistanceOfOnePixel(GetComponentInParent<Canvas>());


        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale * measureValue;
        StartCoroutine(TimerToDel());
        StartCoroutine(FlyTime());

        newPos = targetTransform.position;
    }

    IEnumerator TimerToDel()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }

    IEnumerator FlyTime()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.AddRelativeForce(randomDirection * throwForce * measureValue, ForceMode2D.Impulse);
        yield return new WaitForSeconds(FlyTimeVal);
        toMove = true;
        rb.simulated = false;
    }

    float GetWorldDistanceOfOnePixel(Canvas canvas)
    {
        Camera cam = (canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : canvas.worldCamera;

        Vector3 screenP0 = new Vector2(0, 0);
        Vector3 screenP1 = new Vector2(1, 0);

        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasRect, screenP0, cam, out Vector3 worldP0);
        RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasRect, screenP1, cam, out Vector3 worldP1);

        return Vector3.Distance(worldP0, worldP1);
    }

    void FixedUpdate()
    {
        if (toMove) {
            float step = flySpeed * Time.deltaTime*measureValue;

            transform.position = Vector3.MoveTowards(transform.position, newPos, step);

            if (Vector3.Distance(transform.position, newPos) < (deleteNearDistance*measureValue))
            {
                if (sound != null)
                {
                    sound.PlaySound();
                    Destroy(gameObject, sound.sound.clip.length);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

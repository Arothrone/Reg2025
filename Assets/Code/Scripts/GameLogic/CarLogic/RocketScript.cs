using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class RocketScript : MonoBehaviour
{
    public bool flying = false;
    private Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float destoyObjectAfterSeconds = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Prep()
    {
        StartCoroutine(DestroyLater());
        transform.SetParent(null);
        flying = true;
    }

    void FixedUpdate()
    {
        if (flying)
        {
            Vector3 moveVector = -transform.right * speed * Time.fixedDeltaTime;

            Vector3 newPosition = rb.position + moveVector;

            rb.MovePosition(newPosition);
        }
    }

    IEnumerator DestroyLater()
    {
        yield return new WaitForSeconds(destoyObjectAfterSeconds);
        Destroy(gameObject);
    }
}

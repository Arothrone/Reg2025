using System.Net;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class StickToSurface : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool onSurface = false;
    private Vector2 surfaceNormal;
    [SerializeField] float stickForce = 50f;
    private Collider2D myCollider;
    private GameObject remCollisionGO;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && (remCollisionGO == collision.gameObject || remCollisionGO == null))
        {
            
            Vector2 closestPoint = collision.ClosestPoint(transform.position);
            surfaceNormal = (closestPoint - (Vector2)transform.position).normalized;
            
            onSurface = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            remCollisionGO = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == remCollisionGO)
        {
            remCollisionGO = null;
        }
        if (!myCollider.IsTouchingLayers(1 << 8))
        {
            onSurface = false;
        }
    }

    void FixedUpdate()
    {
        if (onSurface)
        {
            rb.AddForce(surfaceNormal * stickForce, ForceMode2D.Force);
            
        }
    }
}

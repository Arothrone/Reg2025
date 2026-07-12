using UnityEngine;

public class DeleteIf : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float velToDel = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Debug.Log(rb.linearVelocity.magnitude);
        if (rb.linearVelocity.magnitude >= velToDel)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}

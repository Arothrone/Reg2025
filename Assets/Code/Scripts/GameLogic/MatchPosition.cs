using UnityEngine;

public class MatchPosition : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject changing;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = changing.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb.MovePosition(new Vector3(main.transform.position.x, main.transform.position.y, 0));
    }
}

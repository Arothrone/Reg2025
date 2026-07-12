using UnityEngine;

public class MatchPositionAndDelCheck : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject changing;
    [SerializeField] float velToDel = 0.07f;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = changing.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector2 moveTo = new Vector2(main.transform.position.x, main.transform.position.y);
        
        rb.MovePosition(moveTo);
        float distanceThisFrame = Vector2.Distance(rb.position, moveTo);


        if (distanceThisFrame >= velToDel)
        {
            //Destroy(gameObject);
            changing.SetActive(false);
        }
    }
}

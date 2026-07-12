using UnityEngine;

public class RBMassCenter : MonoBehaviour
{
    [SerializeField] float x;
    [SerializeField] float y;

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // X > 0 смещает вес к передним колесам
        // Y < 0 смещает вес максимально низко к дороге
        rb.centerOfMass = new Vector2(x, y);
    }
}

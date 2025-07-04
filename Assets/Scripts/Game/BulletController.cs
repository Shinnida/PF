using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 direction;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = direction*speed;
    }
    public void Direction(Vector2 direction)
    {
        this.direction = direction;
    }
}

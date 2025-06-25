using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 1;
    public float speed = 7f;
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
        else if (!other.CompareTag("Enemy")) // No destruyas si choca con otros enemigos
        {
            Destroy(gameObject);
        }
    }
}

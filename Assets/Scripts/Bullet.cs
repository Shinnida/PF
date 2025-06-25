using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
            Destroy(gameObject);
        }

        if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}


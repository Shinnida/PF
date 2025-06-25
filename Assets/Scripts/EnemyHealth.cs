using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Comentario de Tiro al matar
            Debug.Log("Tiro: ¿Lo mataste? ¡Estoy genuinamente sorprendido!");
            Destroy(gameObject);
        }
    }
}

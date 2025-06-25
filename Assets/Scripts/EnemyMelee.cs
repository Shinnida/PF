using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public int damage = 1;
    public float damageCooldown = 1.5f;
    private bool isTouchingPlayer = false;
    private float damageTimer = 0f;

    void Update()
    {
        if (isTouchingPlayer)
        {
            damageTimer -= Time.deltaTime;

            if (damageTimer <= 0f)
            {
                TryDamagePlayer();
                damageTimer = damageCooldown;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = true;
            damageTimer = 0f; // Daña inmediatamente al contacto
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }

    void TryDamagePlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            PlayerController player = playerObj.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}

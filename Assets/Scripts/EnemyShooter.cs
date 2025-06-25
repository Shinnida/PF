using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    public float detectRange = 6f;
    private float shootTimer;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shootTimer = shootInterval;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        bool isPlayerInFront = IsPlayerInFront();

        if (distanceToPlayer < detectRange && isPlayerInFront)
        {
            shootTimer -= Time.deltaTime;

            if (shootTimer <= 0f)
            {
                Shoot();
                shootTimer = shootInterval;
            }
        }
        else
        {
            shootTimer = shootInterval; // reinicia si sale de rango
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        // Voltea la bala si mira a la izquierda
        if (transform.localScale.x < 0)
        {
            Vector3 bulletScale = bullet.transform.localScale;
            bulletScale.x *= -1;
            bullet.transform.localScale = bulletScale;

            bullet.GetComponent<EnemyBullet>().speed *= -1;
        }

        Debug.Log("Enemigo: ¡Disparo lanzado!");
    }

    bool IsPlayerInFront()
    {
        float dirToPlayer = player.position.x - transform.position.x;
        return (dirToPlayer > 0 && transform.localScale.x > 0) ||
               (dirToPlayer < 0 && transform.localScale.x < 0);
    }
}

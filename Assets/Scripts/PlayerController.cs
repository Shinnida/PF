using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    [Header("Disparo")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    private float nextFireTime;

    [Header("Vida y Mana")]
    public int maxHealth = 5;
    public int currentHealth;

    public int maxMana = 10;
    public int currentMana;
    public int manaCostPerShot = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    void Update()
    {
        // Movimiento
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Disparo
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && currentMana >= manaCostPerShot)
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement.normalized * moveSpeed;
    }

    void Shoot()
    {
        nextFireTime = Time.time + fireRate;
        currentMana -= manaCostPerShot;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = ((Vector2)mousePos - (Vector2)transform.position).normalized;

        bulletRb.linearVelocity = direction * bulletSpeed;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.Save();
    }

    public GameManager gameManager;

}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;

    [Header("Disparo")]
    public GameObject bulletPrefab;
    public Transform gunPoint;
    public float bulletSpeed = 12f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    [Header("Vida")]
    public int maxHealth = 5;
    private int currentHealth;
    private bool isInvincible = false;
    public float invincibilityDuration = 1f;

    [Header("Suelo")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        Mover();
        Saltar();
        Disparar();
    }

    void Mover()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(inputX * moveSpeed, rb.linearVelocity.y);

        if (inputX != 0)
            transform.localScale = new Vector3(Mathf.Sign(inputX), 1, 1);
    }

    void Saltar()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            Debug.Log("Tiro: ¡Wow, qué salto más profesional... para alguien con osteoporosis!");
        }
    }

    void Disparar()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(transform.localScale.x * bulletSpeed, 0);

            Debug.Log("Tiro: ¡Pew pew! ¿Ya te crees un héroe o qué?");
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        currentHealth -= damage;
        Debug.Log("Tiro: Te pegaron otra vez... increíble talento para recibir golpes.");

        if (currentHealth <= 0)
        {
            Debug.Log("Tiro: ¡Y así termina tu carrera estelar, con cero estrellas!");
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }

    System.Collections.IEnumerator BecomeTemporarilyInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }
}

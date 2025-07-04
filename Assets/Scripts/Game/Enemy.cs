using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Enemy : MonoBehaviour
{
    private bool segir = false;
    private Transform positionPlayer;
    private Rigidbody2D rb;
    public float speed;
    public int vida;
    public float distance;
    private Vector2 posicionInicial;
    private string key;
    public static int operator -(Enemy a, BulletController b)
    {
        return a.vida - b.damage;
    }
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
        posicionInicial = transform.position;
        key = posicionInicial.x.ToString() +" + " +posicionInicial.y.ToString();
        if (PlayerPrefs.GetInt(key, 0) == 1)
        {
            Destroy(gameObject);
        }
    }
    protected virtual void Update()
    {
        if (!segir)
        {
            Debug.Log("Entro");
            transform.position = Vector2.MoveTowards(transform.position,posicionInicial, speed * Time.deltaTime);
        }
        else 
        {
            if (Vector2.Distance(transform.position, positionPlayer.position) > distance)
            {
                transform.position = Vector2.MoveTowards(transform.position, positionPlayer.position, speed * Time.deltaTime);
            }
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entro un triger");

        if (collision.gameObject.tag=="Player")
        {
            positionPlayer = collision.transform;
            segir = true;
            Debug.Log("entro");
        }
        else if(collision.gameObject.tag == "Bullet")
        {
            vida = this - collision.GetComponent<BulletController>();
            Destroy(collision.gameObject);
            if(vida <= 0)
            {
                Dead();
                Debug.Log("Morido");
            }
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            positionPlayer = null;
            segir = false;
        }
    }
    protected abstract void Atacar();
    protected virtual void Dead()
    {
        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();
        Destroy(gameObject);
    }
}
 
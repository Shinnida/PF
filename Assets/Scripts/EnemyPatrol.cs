using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyPatrolAndChase : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float chaseRange = 5f;

    private Transform targetPatrol;
    private Transform player;
    private bool chasing = false;

    void Start()
    {
        targetPatrol = pointB;
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        bool isPlayerInFront = IsPlayerInFront();

        if (distanceToPlayer < chaseRange && isPlayerInFront)
        {
            chasing = true;
        }
        else
        {
            chasing = false;
        }

        if (chasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }


    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPatrol.position, patrolSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPatrol.position) < 0.2f)
        {
            targetPatrol = (targetPatrol == pointA) ? pointB : pointA;

            Flip();
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

        if ((player.position.x > transform.position.x && transform.localScale.x < 0) ||
            (player.position.x < transform.position.x && transform.localScale.x > 0))
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    bool IsPlayerInFront()
    {
        float directionToPlayer = player.position.x - transform.position.x;
        return (directionToPlayer > 0 && transform.localScale.x > 0) ||
               (directionToPlayer < 0 && transform.localScale.x < 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(1);
            }
        }
    }



}

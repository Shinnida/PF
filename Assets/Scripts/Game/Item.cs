using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected GameManager gameManager;
    protected abstract void Aplicar(PlayerController playerController);
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            gameManager = player.gameManager;
            Aplicar(player);
            Destroy(gameObject);
        }
    }
}

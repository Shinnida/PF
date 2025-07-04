using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDroop : Enemy
{
    public GameObject[] prefabs;
    protected override void Atacar()
    {

    }
    protected override void Dead()
    {
        int random = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[random],transform.position,transform.rotation);
        base.Dead();
    }
}

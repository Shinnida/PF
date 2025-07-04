using UnityEngine;

public class Monedas : Item
{
    public int monedas;
    public static int operator +(Monedas a, PlayerController b)
    {
        return a.monedas;
    }
    protected override void Aplicar(PlayerController player)
    {
        gameManager.ActualizarMonedas(this+player);
    }
}

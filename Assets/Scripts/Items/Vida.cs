using Unity.Mathematics;

public class Vida : Item
{
    public int vida;
    public static int operator+(Vida a , PlayerController b)
    {
        return math.clamp(b.currentHealth+a.vida,0,b.maxHealth);
    }
    protected override void Aplicar(PlayerController player)
    {
        player.currentHealth = this + player;
    }
}

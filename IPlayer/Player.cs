//To do: max hitpoints, math clamp hitpoints


public class Player : LivingEntity
{
	public Player(int hp, int level) : base(hp, level) {}

    public void DisplayStatus()
    {
        Narrator.WriteLine($"Level: {this.Level} | HP: {this.Hp} / {this.MaxHp}");
    }
}

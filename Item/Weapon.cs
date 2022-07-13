// damage, delay

public class Weapon : IItem
{
    public string Name => "Weapon";
    private int _dmg;
    private int _delay = 3;
    private int _nextAtk = 3;

    public static int SpeedMultiplier;

    public void Attack(LivingEntity target)
    {
        target.Hp--;
    }

    // public void SwordDelay(){
    //     if (_nextAtk > 0){
    //         _nextAtk -= 
    //     }
    // }
        public void AddToInventory(Player player)
    {
        player.Inventory.Add(this);

    }
}
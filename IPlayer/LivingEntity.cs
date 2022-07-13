//classes? hp set based on level. Inventory complexity? Skills?
// TODO: add enum type for the changing state of the hp or level (increased, dereased, or same)
using System;
public class LivingEntity
{
    // When ActionTimer == 0, the LivingEntity can do an action
    public string Name { get; set; }
    public int ActionTimer { get; set; } 
    public int Speed {get; set;}
    public bool IsReady => ActionTimer <= 0;
    // public Weapon LeftHand { get; set; }
    public void CombatTick(){
        if (ActionTimer == 0) {
            ActionTimer -= (Speed * Weapon.SpeedMultiplier);
            // IsReady = true;
    }
    }
    private int _hp;
    private int _prevHp;
    public bool _didHpDecrease;
    public int Hp { get => _hp ; set => SetHp(value); }
    public int MaxHp { get; set; }
    public int Level {get; set;}
    public bool IsDead => Hp <= 0;
    public bool IsAlive => !IsDead;

    
    public readonly List<IItem> Inventory = new List<IItem>();

    public LivingEntity(int hp, int maxHp, int level) {
        this.MaxHp = maxHp;
        this.Hp = hp;
        this.Level = level;
    }

    public LivingEntity(int hp, int level) : this(hp, hp, level) {}

    public void SetHp(int hp) {
        _prevHp = this._hp;
        if (_prevHp > hp) {
            _didHpDecrease = true;
        } else {
            _didHpDecrease = false;
        }
        this._hp = Math.Clamp(hp, 0, this.MaxHp);
    }

    public void Attack(Player player)
    {
        // if (IsReady = true){
        //   player.Hp--;
        // }
    }
    public void UseSkill(){}

    public void UseItem(IItem item)
    {
        item.ItemEffect();
    }
}
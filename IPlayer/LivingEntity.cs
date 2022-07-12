//classes? hp set based on level. Inventory complexity? Skills?
using System;
public class LivingEntity
{
    private int _hp;
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
        this._hp = Math.Clamp(hp, 0, this.MaxHp);
    }

    public void Attack()
    {

    }
    public void UseSkill(){}
}
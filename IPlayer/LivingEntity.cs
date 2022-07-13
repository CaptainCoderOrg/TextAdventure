//classes? hp set based on level. Inventory complexity? Skills?
// TODO: add enum type for the changing state of the hp or level (increased, dereased, or same)
using System;

public class LivingEntity
{
    private int _hp;
    private int _prevHp;
    public bool _didHpDecrease;
    public int Hp { get => _hp ; set => SetHp(value); }
    public int MaxHp { get; set; }
    public int Level {get; set;}
    public bool IsDead => Hp <= 0;
    public bool IsAlive => !IsDead;

    //Is this the correct way to make this?
    public readonly Inventory inventory = new Inventory();

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

    public void Attack()
    {

    }
    public void UseSkill(){}
}
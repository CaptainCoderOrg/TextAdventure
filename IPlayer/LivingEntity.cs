//classes? hp set based on level. Inventory complexity? Skills?
// TODO: add enum type for the changing state of the hp or level (increased, dereased, or same)
using System;
public class LivingEntity
{
    private int _hp;
    private int _prevHp;
    private int _level;
    private int _prevLevel;
    public StateOfChange hpState;
    public StateOfChange levelState;
    public int Hp { get => _hp; set => SetHp(value); }
    public int MaxHp { get; set; }
    public int Level { get => _level; set => SetLevel(value); }

    

    public bool IsDead => Hp <= 0;
    public bool IsAlive => !IsDead;


    public readonly List<IItem> Inventory = new List<IItem>();

    public LivingEntity(int hp, int maxHp, int level)
    {
        this.MaxHp = maxHp;
        this.Hp = hp;
        this.Level = level;
    }

    public LivingEntity(int hp, int level) : this(hp, hp, level) { }

    public void SetHp(int newHp)
    {
        _prevHp = this._hp;
        if (_prevHp > newHp)
        {
            hpState = StateOfChange.Decreased;
        }
        else if (_prevHp < newHp)
        {
            hpState = StateOfChange.Increased;
        } else {
            hpState = StateOfChange.Same;
        }
        this._hp = Math.Clamp(newHp, 0, this.MaxHp);
    }

    public void SetLevel(int newLevel) {
        _prevLevel = this._level;
        if (_prevLevel > newLevel)
        {
            levelState = StateOfChange.Decreased;
        }
        else if (_prevLevel < newLevel)
        {
            levelState = StateOfChange.Increased;
        } else {
            levelState = StateOfChange.Same;
        }
        this._level = newLevel;
    }

    public void Attack()
    {

    }
    public void UseSkill() { }

    public void UseItem(IItem item)
    {
        item.ItemEffect();
    }
}

public enum StateOfChange { Decreased, Same, Increased }
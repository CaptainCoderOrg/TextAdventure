public class Chimera : LivingEntity
{

  public Chimera() :base(15, 8){}

  public void Attack(LivingEntity target)
  {
      target.Hp -= 10;

  }

  public void UseSkill(LivingEntity target, params LivingEntity[] otherTargets)
  {
      //AoE Breath Attack!
      Console.WriteLine("The chimera's breath erupts in a burst of flame!");
      foreach(LivingEntity entity in otherTargets)
      {
        entity.Hp -= 10;

      }
  }
}
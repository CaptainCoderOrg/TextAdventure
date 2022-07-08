//To do: max hitpoints, math clamp hitpoints


public class Player
{
	public int Hp {get; set;}
	public List<IItem> Inventory = new List<IItem>();
	
	Player(int hp)
	{
		this.Hp = hp;
	}
}

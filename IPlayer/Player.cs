public class Player
{
	int hp {get; set;}
	public List<IItem> Inventory = new List<IItem>();
	
	Player(int Hp)
	{
		hp = Hp;
	}
}

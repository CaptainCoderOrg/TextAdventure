public class Player
{
	int hp {get; set;}
	List<IItem> Inventory = new List<IItem>();
	
	Player(int Hp)
	{
		hp = Hp;
	}
}

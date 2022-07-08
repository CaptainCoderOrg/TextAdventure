	public class GnarledTree
	{
		//After examine
		public void GnarledTreePuzzle(Player player, Key key, FishingPole fishingpole)
		{
			Console.WriteLine("There is an old gnarled tree sitting a lonesome part of the forest.");
			Console.WriteLine("As you examine the tree you find that there is a hollow at its center."); 			//Gnarled Tree Hollow is Discovered.
			Console.WriteLine("You can feel something within the hollow but it is just out of reach...");			//If player reaches in.
			if(player.Inventory.Contains(fishingpole)) 																//& input asks to use use fishing pole on hollow. Use FishingPole on Hollow
			{
				Console.WriteLine("As you cast the fishing pole line into the hollow you can feel it catch onto something. When you remove the item you find a small key.");
				key.AddToInventory(player);
			}
		}
		
		
	}

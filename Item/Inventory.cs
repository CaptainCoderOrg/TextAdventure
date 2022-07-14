public class Inventory
{
	public Dictionary<string, IItem> ItemsInInventory = new   Dictionary<string, IItem>();
  Dictionary<(IItem, IItem), IItem> Recipes = new ();
	
	
	public void AddToInventory(IItem item)
	{
		ItemsInInventory.Add(item.Name, item);
	}

  	public void RemoveFromInventory(IItem item)
	{
		ItemsInInventory.Remove(item.Name);
	}
	
	public void DisplayInventory()
	{
		foreach(KeyValuePair <string, IItem> items in this.ItemsInInventory)
		{
			Console.WriteLine($"Item: {items.Key}");	
		}
	}
	
	public void UseItem(string item)
	{
		if(ItemsInInventory.ContainsKey(item))
		{
			IItem x = ItemsInInventory[item];
			x.ItemEffect();
        if(x.IsConsumable() == true)
        {
         RemoveFromInventory(x);
        }
		}
		else
		{
			Console.WriteLine("I don't think I have that item");
		}
	}
}

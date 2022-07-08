	public class Tree
	{
		//Need to add apples
		public List<Apple> apples = new List<Apple>();
		public List<Apple> applesOnGround = new List<Apple>();
		
		
		public void CreateApples()
		{
			for(int i = 0; i < 3; i++)
			{
				Apple x = new Apple();
				apples.Add(x);
			}
		}
		
		public void ShakeTree()
		{
				if(apples.Count > 0)
					{
						Console.WriteLine("An apple fell from the tree!");
				 		apples.RemoveAt(0);
					}
				else
				{
					Console.WriteLine("It doesn't seem to have any more apples.");
				}
		}
	}

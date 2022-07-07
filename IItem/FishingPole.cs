public class FishingPole : IItem
{
    string name;
    
    public FishingPole(string Name)
    {
        name = Name;
    }
    public void ItemEffect()
    {
        Console.WriteLine("You cast out your line!");
    }
    public void AddToInventory(){}
}
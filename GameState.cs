// Keeps track of location within the world
public class GameState
{
    public static readonly GameState Instance = new ();
    public readonly Player Player = new (10, 1);
    private ILocation currentLocation = new Cottage();

    public void DisplayRoom()
    {
        Narrator.WriteLine(currentLocation.Name);
        Narrator.WriteLine("-------------");
        Narrator.WriteLine(currentLocation.Description);
        currentLocation.LocationMenu.DisplayMenu();
    }

    internal void SetLocation(ILocation location)
    {
        this.currentLocation = location;
    }

    public GameState()
    {

    }

}
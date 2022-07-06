// Keeps track of location within the world
public class GameState
{
    private ILocation currentLocation = new Cottage();

    public void DisplayRoom()
    {
        Console.WriteLine(currentLocation.Name);
        Console.WriteLine("-------------");
        Console.WriteLine(currentLocation.Description);
        List<string> options = currentLocation.GetOptions();
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }

        string userInput = " ";
        int asInt = 0;
        while (int.TryParse(userInput, out asInt) == false || asInt < 1 || asInt > options.Count)
        {
            Console.WriteLine("Select an option: ");
            userInput = Console.ReadLine()!;
            if (userInput == null)
            {
                throw new Exception("Reached end of input. Contact your system admin.");
            }
        }

        currentLocation.HandleInput(asInt, this);

    }

    internal void SetLocation(ILocation location)
    {
        this.currentLocation = location;
    }

    public GameState()
    {

    }

}
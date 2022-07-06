public class Dungeon : ILocation 
{
    public static readonly Dungeon Instance = new Dungeon();
    public string Description => "You enter a dungeon. It is dark.";
    public string Name => "Dungeon";

    private List<string> options;

    private bool hasCandle = false;
    private bool hasLitCandle = false;

    public Dungeon()
    {
        options = new List<string>();
        options.Add("Exit dungeon");
        options.Add("Examine the dungeon");

        if (hasCandle){
            options.Add("Light a candle");
        }
    }
    public List<string> GetOptions()
    {
        return options;
    }
    public void HandleInput(int option, GameState gs)
    {
        switch (option){
            case 1:
                Narrator.WriteLine("You walk back to the tunnel.");
                // gs.SetLocation(new Tunnel());
                break;
                // must have a candle in your inventory (Add later)
            case 2:
            if (hasCandle)
            {
                Narrator.WriteLine("You light a candle.");
            } else if (!hasCandle)
            {
                Narrator.WriteLine("You don't have a candle");
            }
                break;
            case 3:
            if (!hasCandle)
            {
                Narrator.WriteLine("The dungeon is too dark to examine.");
            } else if (hasLitCandle)
            {
                Narrator.WriteLine("You look around the dungeon.");
            }
            break;
        }
    }
    private void ExitDungeon()
    {

    }

    private void ExamineDungeon()
    {

    }


}
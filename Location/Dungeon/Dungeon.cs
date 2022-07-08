public class Dungeon : ILocation 
{
    public static readonly Dungeon Instance = new Dungeon();
    public string Description => "You enter a dungeon. It is dark.";
    public string Name => "Dungeon";

    public Menu LocationMenu { get; }
    private bool hasLitCandle = false;

    public Dungeon()
    {
        LocationMenu = new Menu();
        MenuItem exit = new MenuItem("Exit Dungeon", ExitDungeon);
        LocationMenu.AddItem(exit);

        MenuItem examine = new MenuItem("Examine Dungeon", ExamineDungeon);
        LocationMenu.AddItem(examine);

        MenuItem candle = new MenuItem("Light Candle", LightCandle);
        LocationMenu.AddItem(candle);


    }

    private void ExitDungeon()
    {
        Narrator.WriteLine("Exit the dungeon.");
        GameState.Instance.SetLocation(TunnelEntrance.Instance);
    }

    private void ExamineDungeon()
    {
        Narrator.WriteLine("It is too dark to look around.");
        if (hasLitCandle){
        Narrator.WriteLine("You examine the Dungeon. ");
        }
    }

    private void LightCandle(){
        Narrator.WriteLine("You pick up and light a candle that was sitting on the floor.");
        hasLitCandle = true;
        Narrator.WriteLine("You can see the room now.");
    }

}
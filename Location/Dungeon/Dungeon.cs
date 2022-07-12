public class Dungeon : ILocation 
{
    public static readonly Dungeon Instance = new Dungeon();
    public string Description => GetDescription();
    public string Name => "Dungeon";

    public Menu LocationMenu { get; }
    private bool hasLitCandle = false;

    private readonly MenuItem _newPathway;

    public Dungeon()
    {
        LocationMenu = new Menu();
        MenuItem exit = new MenuItem("Exit Dungeon", ExitDungeon);
        LocationMenu.AddItem(exit);

        MenuItem examine = new MenuItem("Examine Dungeon", ExamineDungeon);
        LocationMenu.AddItem(examine);

        MenuItem candle = new MenuItem("Light Candle", LightCandle);
        LocationMenu.AddItem(candle);

        _newPathway = new MenuItem ("Enter Pathway", EnterPathway);
        _newPathway.IsEnabled = false;
        LocationMenu.AddItem(_newPathway);


    }

    private string GetDescription(){
       string desc = "You enter a dungeon. It is dark.";
       return desc;
    }
    private void ExitDungeon()
    {
        Narrator.WriteLine("Exit the dungeon.");
        GameState.Instance.SetLocation(TunnelEntrance.Instance);
    }

    private void ExamineDungeon()
    {
        if (hasLitCandle){
            
        Narrator.WriteLine("You examine the Dungeon. ");
        Narrator.WriteLine("----------------------------");
        Narrator.WriteLine("There seems to be a long path.");
        _newPathway.IsEnabled = true;

        
        } else {
            Narrator.WriteLine("It is too dark to look around.");

        }
        GetDescription();
    }
    private void EnterPathway(){
        GameState.Instance.SetLocation(Pathway.Instance);
    }

    private void LightCandle(){
        Narrator.WriteLine("You pick up and light a candle that was sitting on the floor.");
        hasLitCandle = true;
        Narrator.WriteLine("You can see the room now.");
    }

}
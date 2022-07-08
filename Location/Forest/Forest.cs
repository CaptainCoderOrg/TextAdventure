public class Forest : ILocation
{
    public readonly static Forest Instance = new Forest();
    public string Description => "A dense woodline surrounds the cottage in an endless ocean of bark and leaves.";

    public Menu menu;
    public string Name => "Forest";
    //public bool isTunnelDiscovered = false;
    private List<string> options = new List<string>();

    public Forest()
    {
        menu = new Menu();
        MenuItem exit = new MenuItem("Enter Cottage", EnterCottage);
        menu.AddItem(exit);

    }

     public List<string> GetOptions()
     {
         return options;
     }

    private void EnterCottage()
    {
        Narrator.WriteLine("You turn away from the forest and enter the cottage.");
        GameState.Instance.SetLocation(Cottage.Instance);
        // TODO: Connect Cottage
    }
    public void HandleInput(int option, GameState gs)
    {
        switch (option) {
            case 1:
                Narrator.WriteLine("You turn away from the forest and enter the cottage.");
                gs.SetLocation(Cottage.Instance);
                // TODO: Connect Cottage
                break;
            case 2:
                Narrator.WriteLine("The forest seems to go on forever yet you can't hear any birds singing or animals moving within.");
                Narrator.WriteLine("As you search the forest you find a overgrown tunnel leading into the darkness and get a strange sense of deja vu...");
                break;
            case 3:
                Narrator.WriteLine("You walk deeper into the forest, trying to find a way out. After a few minutes of traveling you come across a small only to realize you've travelled in a circle.");
                break;
            case 4:
                //if => you don't a weapon Narrator.WriteLine("You feel a grave sense of danger lurking within the tunnel and wonder if it is truly safe to enter...");
                //else...
                Narrator.WriteLine("You enter the tunnel");
                gs.SetLocation(TunnelEntrance.Instance);
                break;
            case 5:
                Narrator.WriteLine("The tunnel seems like it was abandoned along time ago. A faint, warm wind caresses your face from its mouth.");
                break;
            case 6:
                Narrator.WriteLine("You shout into the tunnel and can hear your voice echo back to you before sharply cutting off.");
                break;
            default:
                break;
        }
    }
}
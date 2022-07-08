public class Forest : ILocation
{
    public readonly static Forest Instance = new Forest();
    public string Description => "A dense woodline surrounds the cottage in an endless ocean of bark and leaves.";

    public Menu LocationMenu { get; }
    public string Name => "Forest";
    //public bool isTunnelDiscovered = false;
    private List<string> options = new List<string>();

    public Forest()
    {
        LocationMenu = new Menu();
        MenuItem exit = new MenuItem("Enter Cottage", EnterCottage);
        MenuItem examine = new MenuItem("Examine", Examine);
        MenuItem leaveforest = new MenuItem("Leave Forest", LeaveForest);
        MenuItem entertunnel = new MenuItem("Enter Tunnel", EnterTunnel);
        MenuItem examinetunnel = new MenuItem("Examine Tunnel", ExamineTunnel);
        MenuItem shoutintotunnel = new MenuItem("Shout into the tunnel", ShoutIntoTunnel);
        LocationMenu.AddItem(exit);
        LocationMenu.AddItem(examine);
        LocationMenu.AddItem(leaveforest);
        LocationMenu.AddItem(entertunnel);
        LocationMenu.AddItem(examinetunnel);
        LocationMenu.AddItem(shoutintotunnel);

    }

    private void EnterCottage()
    {
        Narrator.WriteLine("You turn away from the forest and enter the cottage.");
        GameState.Instance.SetLocation(Cottage.Instance);
        // TODO: Connect Cottage
    }
    private void Examine()
    {
        Narrator.WriteLine("The forest seems to go on forever yet you can't hear any birds singing or animals moving within.");
        Narrator.WriteLine("As you search the forest you find a overgrown tunnel leading into the darkness and get a strange sense of deja vu...");
        GameState.Instance.SetLocation(Cottage.Instance);
        // TODO: Connect Cottage
    }
    private void LeaveForest()
    {
        Narrator.WriteLine(@"You walk deeper into the forest, trying to find a way out.
        After a few minutes of traveling you come across a small only to realize you've travelled in a circle.");
    }
    private void EnterTunnel()
    {
        Narrator.WriteLine("You enter the tunnel");
        GameState.Instance.SetLocation(TunnelEntrance.Instance);
    }
    private void ExamineTunnel()
    {
        Narrator.WriteLine("The tunnel seems like it was abandoned along time ago. A faint, warm wind caresses your face from its mouth.");

    }

    private void ShoutIntoTunnel()
    {
        Narrator.WriteLine("You shout into the tunnel and can hear your voice echo back to you before sharply cutting off.");

    }
}
    
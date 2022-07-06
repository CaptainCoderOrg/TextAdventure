public class Forest : ILocation
{
    public string Description => "A dense woodline surrounds the cottage in an endless ocean of bark and leaves.";

    public string Name => "Forest";
    //public bool isTunnelDiscovered = false;
    private List<string> options;

    public Forest()
    {
        options = new List<string>();
        options.Add("Enter Cottage");
        options.Add("Examine Forest");
        //if(isDiscovered == true)
        //{
        options.Add("Examine Tunnel");
        options.Add("Shout into Tunnel");
        options.Add("Enter Tunnel");
        //}
    }

    public List<string> GetOptions()
    {
        return options;
    }

    public void HandleInput(int option, GameState gs)
    {
        switch (option) {
            case 1:
                Narrator.WriteLine("You turn away from the forest and enter the cottage.");
                gs.SetLocation(new DownStairs());
                // TODO: Connect Cottage
                break;
            case 2:
                Narrator.WriteLine("The forest seems to go on forever yet you can't hear any birds singing or animals moving within.");
                Narrator.WriteLine("As you search the forest you find a overgrown tunnel leading into the darkness and get a strange sense of deja vu...");
                break;
            case 3:
                //if => you don't a weapon Narrator.WriteLine("You feel a grave sense of danger lurking within the tunnel and wonder if it is truly safe to enter...");
                //else...
                Narrator.WriteLine("You enter the tunnel");
                //gs.SetLocation(new Tunnel());
                break;
            case 4:
                Narrator.WriteLine("The tunnel seems like it was abandoned along time ago. A faint, warm wind caresses your face from its mouth.");
                break;
            case 5:
                Narrator.WriteLine("You shout into the tunnel and can hear your voice echo back to you before sharply cutting off.");
                break;
            default:
                break;
        }
    }
}
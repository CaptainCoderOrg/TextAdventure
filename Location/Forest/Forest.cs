public class Forest : ILocation
{
    public readonly static Forest Instance = new Forest();
    public readonly static Tree tree = new Tree();
    public string Description => "A dense woodline surrounds the cottage in an endless ocean of bark and leaves.";


    public Menu LocationMenu { get; }
    public string Name => "Forest";
    
    public bool AreaExamined = false;
    public bool HollowDiscovered = true;
    private readonly MenuItem examinetunnel, shoutintotunnel, entertunnel, examineGnarledTree, examineHollow, shakeTree;

    public Forest()
    {
        LocationMenu = new Menu();
        MenuItem exit = new MenuItem("Enter Cottage", EnterCottage);
        MenuItem examine = new MenuItem("Examine Forest", ExamineForest);
        MenuItem leaveforest = new MenuItem("Leave Forest", LeaveForest);
        shakeTree = new MenuItem("Shake Tree", ShakeTreeinForest);
        examineGnarledTree = new MenuItem("Examine Gnarled Tree", ExamineGnarledTree);
        examineHollow = new MenuItem("Examine Hollow", ExamineHollow);
        // MenuItem Use = new MenuItem("Use", UseItem);
        entertunnel = new MenuItem("Enter Tunnel", EnterTunnel);
        examinetunnel = new MenuItem("Examine Tunnel", ExamineTunnel);
        shoutintotunnel = new MenuItem("Shout into the tunnel", ShoutIntoTunnel);
        LocationMenu.AddItem(exit);
        LocationMenu.AddItem(examine);
        LocationMenu.AddItem(leaveforest);
        LocationMenu.AddItem(shakeTree);
        LocationMenu.AddItem(examineGnarledTree);
        LocationMenu.AddItem(examineHollow);
        LocationMenu.AddItem(entertunnel);
        LocationMenu.AddItem(examinetunnel);
        LocationMenu.AddItem(shoutintotunnel);

        examinetunnel.IsEnabled = false;
        shoutintotunnel.IsEnabled = false;
        entertunnel.IsEnabled = false;
        examineGnarledTree.IsEnabled = false;
        examineHollow.IsEnabled = false;
        shakeTree.IsEnabled = false;
    }

    private void EnterCottage()
    {
        Narrator.WriteLine("You turn away from the forest and enter the cottage.");
        GameState.Instance.SetLocation(Cottage.Instance);

    }
    private void ExamineForest()
    {
        if(AreaExamined == false)
        {
            Narrator.WriteLine("As you search the forest you find a overgrown tunnel leading into the darkness and get a strange sense of deja vu...");
            Narrator.WriteLine("In the distance you can see an old gnarled tree sitting by itself. In the opposite direction you find a overgrown tunnel, leading into darkness");
            examinetunnel.IsEnabled = true;
            shoutintotunnel.IsEnabled = true;
            entertunnel.IsEnabled = true;
            examineGnarledTree.IsEnabled = true;
            shakeTree.IsEnabled = true;
            
            
            tree.CreateApples();
            AreaExamined = true;
        }
        else
        {
            Narrator.WriteLine("You are in the forest near the cottage, tunnel, & trees.");
            Narrator.WriteLine("A gnarled tree sits alone in a small field.");
        }
    }
    private void LeaveForest()
    {
        Narrator.WriteLine(@"You walk deeper into the forest, trying to find a way out.
        After a few minutes of traveling you come across a small only to realize you've travelled in a circle.");
    }
        private void ShakeTreeinForest()
    {
        tree.ShakeTree();
    }
    private void ExamineGnarledTree()
    {
        if(HollowDiscovered == true)
        {
            Narrator.WriteLine("As you examine the tree you find that there is a hollow at its center.");
            examineHollow.IsEnabled = true;
        }
        else
        {
            Narrator.WriteLine("A gnarled old tree with a large hollow in its center.");
        }
    }
        private void ExamineHollow()
    {
        if(HollowDiscovered == true)
        {
            Narrator.WriteLine("You look into the hollow and can see something glimmering from within but too far down to reach.");
        }
    }

    // --- This doesn't seem right -----------------------------------------------------------------------------------------
    // private void UseItem()
    // {
    //     Narrator.WriteLine("What item would you like to use?");
    //     player.DisplayInventory();
    //     //How to ask a player what item that they would like to use? How to create an inventory menu?
    //     //If an item is appropriate item is used then effect happens.
    //     //How to create a method that combines items?

    // }
    private void EnterTunnel()
    {
        if(AreaExamined == true)
        {
            Narrator.WriteLine("You enter the tunnel");
            GameState.Instance.SetLocation(TunnelEntrance.Instance);
        }
        else
        {
            Narrator.WriteLine("");
        }
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
    
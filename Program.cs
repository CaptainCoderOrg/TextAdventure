// See https://aka.ms/new-console-template for more information
//

// Planning:
// Text Adventure:
// What classes / interfaces do we need?
// Something to represent Rooms / Locations
//   - Navigation / Options / Menu
// Game Over / Game Won?
// GameState Class
// GameEvent Class?
// Player Class
//   - Stats / Location / Dialog
// Inventory
//   - ???
// Item Class
//   - Weapon
//   - Armor
//   - Consumable
// Combat System??
// Enemy Class
// NPC Class
// 


public class Program 
{

    public static void Main()
    {
        // Narrator.WriteLine("Hello World!", .1);
        // GameState gs = new GameState();
        // while(true)
        // {
        //     gs.DisplayRoom();
        // }
        Menu main = new Menu();
        MenuItem play = new MenuItem("Play", Play);
        MenuItem inventory = new MenuItem("Inventory", () => Narrator.WriteLine("Show Inventory!"));
        inventory.IsHidden = false;
        MenuItem load = new MenuItem("Load", () => Narrator.WriteLine("Load Selected"));
        load.IsEnabled = false;
        MenuItem exit = new MenuItem("Exit", () => Narrator.WriteLine("Exit Selected"));
        main.AddItem(play);
        main.AddItem(inventory);
        main.AddItem(load);
        main.AddItem(exit);
        main.DisplayMenu();
    }

    private static void Play() => Narrator.WriteLine("Play Selected");

}

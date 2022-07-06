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
        GameState gs = new GameState();
        while(true)
        {
            gs.DisplayRoom();
        }
    }

}

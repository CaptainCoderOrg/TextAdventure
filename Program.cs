// See https://aka.ms/new-console-template for more information
//
// Test
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


//Notes - Ryan; Adjusted my forest. Added Display Inventory to Player so it can show that characters specific inventory. Add "Use Item" to Living Entity.
//Issues - Found that I ran into issues when wanting to use items from the inventory. I wasn't able to use items within the inventory.
//Issues - Found adding complexity to forest options and menu was overbearing at times. Require a method for creating menu options easier. No solution reccommended.
//Solution? - Add an option to user Input that takes in a string like "useitem" that will Display the inventory and allow users to choose an item to use.
//

public class Program 
{

    public static void Main()
    {        

        // Narrator.WriteLine("Hello World!", .1);
        //while GameOver = false?
        while(GameState.Instance.Player.IsAlive)
        {
            GameState.Instance.Player.DisplayStatus();
            GameState.Instance.DisplayRoom();
        }
        Narrator.WriteLine("You Died!");
        // Menu main = new Menu();
        // MenuItem play = new MenuItem("Play", Play);
        // MenuItem inventory = new MenuItem("Inventory", () => Narrator.WriteLine("Show Inventory!"));
        // inventory.IsHidden = false;
        // MenuItem load = new MenuItem("Load", () => Narrator.WriteLine("Load Selected"));
        // load.IsEnabled = false;
        // MenuItem exit = new MenuItem("Exit", () => Narrator.WriteLine("Exit Selected"));
        // main.AddItem(play);
        // main.AddItem(inventory);
        // main.AddItem(load);
        // main.AddItem(exit);
        // main.DisplayMenu();
    }

    private static void Play() => Narrator.WriteLine("Play Selected");

}

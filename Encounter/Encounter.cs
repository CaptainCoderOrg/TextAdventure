using System.IO;
public class Encounter
{
    private readonly List<LivingEntity> _enemies = new();
    private readonly List<Player> _players = new ();
    private readonly string _screenTemplate;
    private readonly string _rowTemplate;

    public Encounter(params LivingEntity[] combatants)
    {
        _screenTemplate = File.ReadAllText("assets/screens/Combat.txt");
        _rowTemplate = File.ReadAllText("assets/screens/Combat_row.txt");
        foreach (LivingEntity e in combatants)
        {
            if (typeof(Player).IsInstanceOfType(e))
            {
                this._players.Add((Player)e);
            } 
            else
            {
                this._enemies.Add(e);
            }
        }
    }

    public void Display()
    {
        Console.Clear();
        string screen = _screenTemplate;
        string rows = "";
        
        foreach (LivingEntity entity in _enemies)
        {
            string row = _rowTemplate;
            string name = entity.Name.Length <= 13 ? entity.Name.PadRight(13) : entity.Name.PadRight(13).Substring(0, 10) + "...";
            row = row.Replace("{NAME}".PadRight(13), name);
            row = row.Replace("{HP}".PadRight(3), entity.Hp.ToString().PadLeft(3));
            row = row.Replace("{MAX_HP}".PadRight(3), entity.MaxHp.ToString().PadLeft(3));
            rows += row + "\n";
        }
        screen = screen.Replace("{COMBAT_ROWS}\n", rows);
        Console.WriteLine(screen);
    }

    public static void Test()
    {
        GameState.Instance.Player.Name = "Bob the Destroyer of Many Worlds";
        Encounter e = new Encounter(GameState.Instance.Player, new Goblin(), new TunnelWorm(), new Zombie());
        e.Display();
    }
}
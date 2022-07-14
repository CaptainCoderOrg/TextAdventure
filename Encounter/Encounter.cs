using System.IO;
public class Encounter
{
    private readonly List<LivingEntity> _enemies = new();
    private readonly List<Player> _players = new();
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

        int rowCount = Math.Max(_enemies.Count, _players.Count);
        for (int i = 0; i < rowCount; i++)
        {
            string row = _rowTemplate;
            LivingEntity? enemy = i < _enemies.Count ? _enemies[i] : null;
            Player? player = i < _players.Count ? _players[i] : null;
            rows += AddRow(enemy, player) + "\n";        
        }
        screen = screen.Replace("{COMBAT_ROWS}\n", rows);
        Console.WriteLine(screen);
    }

    private string AddRow(LivingEntity? enemy, Player? player)
    {
        string row = _rowTemplate;
        AddLeftColumn(ref row, enemy);
        AddRightColumn(ref row, player);
        return row;
    }

    private void AddLeftColumn(ref string row, LivingEntity? enemy) 
    {
        string enemyName = enemy == null ? string.Empty : enemy.Name;
        string hp = enemy == null ? string.Empty : enemy.Hp.ToString();
        string maxHp = enemy == null ? string.Empty : enemy.MaxHp.ToString();
        enemyName = enemyName.Length <= 12 ? enemyName.PadRight(12) : enemyName.PadRight(12).Substring(0, 9) + "...";
        row = row.Replace("{NAME}".PadRight(12), enemyName);
        row = row.Replace("{HP}".PadRight(3), hp.PadLeft(3));
        row = row.Replace("{MAX_HP}".PadRight(3), maxHp.PadLeft(3));
    }
    private void AddRightColumn(ref string row, Player? player)
    {
        string playerName = player == null ? string.Empty : player.Name;
        string hp = player == null ? string.Empty : player.Hp.ToString();
        string maxHp = player == null ? string.Empty : player.MaxHp.ToString();
        playerName = playerName.Length <= 12 ? playerName.PadRight(12) : playerName.PadRight(12).Substring(0, 10) + "...";
        row = row.Replace("{Player Name}".PadRight(11), playerName);
        row = row.Replace("{pHP}".PadRight(3), hp.PadLeft(2));
        row = row.Replace("{pMAX_HP}".PadRight(3), maxHp.PadLeft(3));
    }

    public static void Test()
    {
        GameState.Instance.Player.Name = "Bob the of Many Worlds";
        Encounter e = new Encounter(GameState.Instance.Player, GameState.Instance.Player, GameState.Instance.Player, new Zombie());
        e.Display();
    }
}
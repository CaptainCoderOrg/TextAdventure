
public interface ILocation
{
    public string Description { get; }
    public string Name { get; }
    public List<string> GetOptions();
    public void HandleInput(int option, GameState gs);
    
}
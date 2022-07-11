
public class Recipe
{
    private static Dictionary<string, Recipe> RecipeRegistry = new Dictionary<string, Recipe>();
    public readonly List<IItem> Ingredients;
    public readonly IItem Result;

    public Recipe(List<IItem> ingredients, IItem result)
    {
        this.Ingredients = ingredients;
        this.Result = result;
        ingredients.Sort((item0, item1) => item0.ToString()!.CompareTo(item1.ToString()));
        String key = String.Join(",", ingredients);
        RecipeRegistry[key] = this;
    }

    public static Recipe? GetRecipe(List<IItem> ingredients)
    {
        ingredients.Sort((item0, item1) => item0.ToString()!.CompareTo(item1.ToString()));
        String key = String.Join(",", ingredients);
        if (RecipeRegistry.TryGetValue(key, out Recipe? result) && result != null) {
            return result;
        }
        return null;
    }
}
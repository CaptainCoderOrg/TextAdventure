using System.Text.RegularExpressions;

public class Narrator
{

    public static bool DebugMode {get; set;} = false;
    public static double DefaultDelay {get; set;} = 0.01;

    private static readonly Dictionary<string, ConsoleColor> _keywords = new();

    /// <summary>
    /// Writes the specified text to the console one character at a time with the given delay in seconds.
    /// </summary>
    /// <param name="toWrite">The string to write to the console</param>
    /// <param name="delay">Optional number of seconds per character</param>
    public static void Write(string toWrite, double delay = -1)
    {
        if (DebugMode)
        {
            Console.Write(toWrite);
            return;
        }
        delay = delay == -1 ? DefaultDelay : delay;
        int millis = (int)(1000 * delay);
        // Splits the text on white spaces and periods but does not discard them in the result.
        string[] tokens = Regex.Split(toWrite, "([\\s.,])");
        DoWrite(tokens, millis);
        
    }

    /// <summary>
    /// Writes the specified text to the console one character at a time and adds a new line with the given delay in seconds.
    /// </summary>
    /// <param name="toWrite">The string to write to the console</param>
    /// <param name="delay">Optional number of seconds per character</param>
    public static void WriteLine(string toWrite, double delay = -1) => Write(toWrite + '\n', delay);

    private static void DoWrite(string[] tokens, int millis)
    {
        ConsoleColor orig = Console.ForegroundColor;
        foreach (string token in tokens)
        {
            if (_keywords.TryGetValue(token.ToLower(), out ConsoleColor color))
            {
                Console.ForegroundColor = color;
            }
            foreach (char ch in token)
            {
                Console.Write(ch);
                Thread.Sleep(millis);
            }
            Console.ForegroundColor = orig;
        }
    }

    /// <summary>
    /// Add one or more non-case sensitive keywords to the Narrator.
    /// </summary>
    /// <param name="color">The color of the keywords</param>
    /// <param name="keywords">The keywords to add</param>
    public static void AddKeyWords(ConsoleColor color, params string[] keywords)
    {
        foreach (string keyword in keywords)
        {
            _keywords[keyword.ToLower()] = color;
        }
    }

    /// <summary>
    /// Removes one or more non-case sensitive keywords from the Narrator.
    /// </summary>
    /// <param name="keywords">The keywords to remove</param>
    public static void ClearKeyWords(params string[] keywords)
    {
        foreach (string keyword in keywords)
        {
            _keywords.Remove(keyword.ToLower());
        }
    }

    /// <summary>
    /// Removes all keywords from the Narrator.
    /// </summary>
    public static void ClearAllKeyWords() => _keywords.Clear();


    

}
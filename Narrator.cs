
public class Narrator
{
    public static void Write(string toWrite, double delay = .05)
    {
        int millis = (int)(1000 * delay);
        foreach (char ch in toWrite)
        {
            Console.Write(ch);
            Thread.Sleep(millis);
        }
    }

    public static void WriteLine(string toWrite, double delay = .05) => Write(toWrite + '\n', delay);

}
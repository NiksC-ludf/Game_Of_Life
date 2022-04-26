namespace GameOfLife;

/// <summary>
/// Applications main class.
/// </summary>
public class Program
{
    static void Main()
    {
        GameManager gameManager = new GameManager();
        gameManager.Play();
    }
}
using System.Text.Json;

public class Ending
{
    public string _over1;
    public string _over2;
    public string _over3;

    public string over1
    {
        get { return _over1; }
        set { _over1 = value; }
    }
    public string over2
    {
        get { return _over2; }
        set { _over2 = value; }
    }
    public string over3
    {
        get { return _over3; }
        set { _over3 = value; }
    }

    public static Ending EndGame()
    {
        Stream StreamGame = new FileStream(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetFullPath("GameOver.json"))))) + "\\GameOver.json", FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite);
        string FileeData = new StreamReader(StreamGame).ReadToEnd();
        GameEnd OverGaming = JsonSerializer.Deserialize<GameEnd>(FileeData);
        return OverGaming;
        
    }
}

public class GameEnd : Ending
{
    public string over1
    {
        get { return _over1; }
        set { _over1 = value; }
    }

    public string over2
    {
        get { return _over2; }
        set { _over2 = value; }
    }

    public string over3
    {
        get { return _over3; }
        set { _over3 = value; }
    }
}
using System.Text.Json;
public class Winning // в разработке
{
    public string _win1;
    public string _win2;
    public string _win3;

    public string win1
    {
        get { return _win1; }
        set { _win1 = value; }
    }
    public string win2
    {
        get { return _win2; }
        set { _win2 = value; }
    }
    public string win3
    {
        get { return _win3; }
        set { _win3 = value; }
    }

    public static Winning GameWinning()
    {
        Stream StreamWin = new FileStream(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetFullPath("WIN.json"))))) + "\\WIN.json", FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite);
        string FileData = new StreamReader(StreamWin).ReadToEnd();
        Win WinningGame = JsonSerializer.Deserialize<Win>(FileData);
        return WinningGame;
    }
}

public class Win : Winning
{
    public string win1
    {
        get { return _win1; }
        set { _win1 = value; }
    }
    public string win2
    {
        get { return _win2; }
        set { _win2 = value; }
    }
    public string win3
    {
        get { return _win3; }
        set { _win3 = value; }
    }
}
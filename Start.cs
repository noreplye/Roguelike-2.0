using System.Text.Json;

public class StartGame
{
    public string _greeting1;
    public string _greeting2;
    public string _greeting3;
    public string _greeting4;
    public string _greeting5;
    public string _greeting6;
    public string _present1;
    public string _present2;
    public string _present3;
    public string _present4;
    public string _present5;
    public string _present6;

    public string greeting1
    {
        get { return _greeting1; }
        set { _greeting1 = value; }
    }
    public string greeting2
    {
        get { return _greeting2; }
        set { _greeting2 = value; }
    }
    public string greeting3
    {
        get { return _greeting3; }
        set { _greeting3 = value; }
    }
    public string greeting4
    {
        get { return _greeting4; }
        set { _greeting4 = value; }
    }
    public string greeting5
    {
        get { return _greeting5; }
        set { _greeting5 = value; }
    }
    public string greeting6
    {
        get { return _greeting6; }
        set { _greeting6 = value; }
    }

    public string present1
    {
        get { return _present1; }
        set { _present1 = value; }
    }
    public string present2
    {
        get { return _present2; }
        set { _present2 = value; }
    }
    public string present3
    {
        get { return _present3; }
        set { _present3 = value; }
    }
    public string present4
    {
        get { return _present4; }
        set { _present4 = value; }
    }
    public string present5
    {
        get { return _present5; }
        set { _present5 = value; }
    }
    public string present6
    {
        get { return _present6; }
        set { _present6 = value; }
    }

   
    public static StartGame StartingGame()
    {
        Stream stream = new FileStream(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetFullPath("StartGame.json"))))) + "\\StartGame.json", FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite);
        string FileData;
        FileData = new StreamReader(stream).ReadToEnd();
        GameName Starting = JsonSerializer.Deserialize<GameName>(FileData);
        return Starting; 
    }
}

public class GameName : StartGame
{
    public string greeting1
    {
        get { return _greeting1; }
        set { _greeting1 = value; }
    }
    public string greeting2
    {
        get { return _greeting2; }
        set { _greeting2 = value; }
    }
    public string greeting3
    {
        get { return _greeting3; }
        set { _greeting3 = value; }
    }
    public string greeting4
    {
        get { return _greeting4; }
        set { _greeting4 = value; }
    }
    public string greeting5
    {
        get { return _greeting5; }
        set { _greeting5 = value; }
    }
    public string greeting6
    {
        get { return _greeting6; }
        set { _greeting6 = value; }
    }
    public string present1
    {
        get { return _present1; }
        set { _present1 = value; }
    }
    public string present2
    {
        get { return _present2; }
        set { _present2 = value; }
    }
    public string present3
    {
        get { return _present3; }
        set { _present3 = value; }
    }
    public string present4
    {
        get { return _present4; }
        set { _present4 = value; }
    }
    public string present5
    {
        get { return _present5; }
        set { _present5 = value; }
    }
    public string present6
    {
        get { return _present6; }
        set { _present6 = value; }
    }
}
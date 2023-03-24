using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

public class Room
{
    protected int _weight;
    protected int _height;
    protected int _xGenPos;
    protected int _yGenPos;
    protected int _roomEvent;
    protected string[][] _roomGraphics;
    protected int[][] _roomObjects;

    public int weight
    {
        get { return _weight; }
        protected set { _weight = value; }
    }
    public int height
    {
        get { return _height; }
        protected set { _height = value; }
    }
    public int xGenPos
    {
        get { return _xGenPos; }
        protected set { _xGenPos = value; }
    }
    public int yGenPos
    {
        get { return _yGenPos; }
        protected set { _yGenPos = value; }
    }
    public int roomEvent
    {
        get { return _roomEvent; }
        protected set { _roomEvent = value; }
    }
    public string[][] roomGraphics
    {
        get { return _roomGraphics; }
        protected set { _roomGraphics = value; }
    }
    public int[][] roomObjects
    {
        get { return _roomObjects; }
        protected set { _roomObjects = value; }
    }
    public static void generateEvent(string[][] Graph, int[][] Objec, int wei, int hei,int roomEvent)
    {
        int idkX = new Random().Next(0, wei);
        int idkY = new Random().Next(0, hei);
        int ok = 0;
        int roomEve;
        if (roomEvent == 0) {roomEve = new Random().Next(3, 7); }
        else {roomEve = roomEvent; }
        while (ok != 1)
        {
            if (Graph[idkY][idkX] == ".")
            {
                if (roomEve == 3) //монстр
                {
                    Graph[idkY][idkX] = "e";
                    Objec[idkY][idkX] = 3;
                }
                if (roomEve == 4) //мирный моб / квест
                {
                    Graph[idkY][idkX] = "?";
                    Objec[idkY][idkX] = 4;
                }
                if (roomEve == 5) //сундук
                {
                    Graph[idkY][idkX] = "с";
                    Objec[idkY][idkX] = 5;
                }
                if (roomEve == 6) //магазин
                {
                    Graph[idkY][idkX] = "m";
                    Objec[idkY][idkX] = 6;
                }
                if (roomEve == 10) //Босс
                {
                    Graph[idkY][idkX] = "K";
                    Objec[idkY][idkX] = 10;
                }
                ok = 1;
            }
            idkX = new Random().Next(0, wei);
            idkY = new Random().Next(0, hei);
        }
    }

    public static Room init(string path)
    {
        Stream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        string fileText;
        fileText = new StreamReader(stream).ReadToEnd();
        temproom obj = JsonSerializer.Deserialize<temproom>(fileText);
        generateEvent(obj._roomGraphics, obj._roomObjects, obj.weight, obj.height, obj.roomEvent);
        return obj; 
    }
}

public class temproom : Room
{


    public int weight
    {
        get { return _weight; }
        set { _weight = value; }
    }
    public int height
    {
        get { return _height; }
        set { _height = value; }
    }
    public int xGenPos
    {
        get { return _xGenPos; }
        set { _xGenPos = value; }
    }
    public int yGenPos
    {
        get { return _yGenPos; }
        set { _yGenPos = value; }
    }
    public int roomEvent
    {
        get { return _roomEvent; }
        set { _roomEvent = value; }
    }
    public string[][] roomGraphics
    {
        get { return _roomGraphics; }
        set { _roomGraphics = value; }
    }
    public int[][] roomObjects
    {
        get { return _roomObjects; }
        set { _roomObjects = value; }
    }


}




// айдишки объектов
// id0  : стена(или не существует)
// id1  : пол по которому можно ходить
// id2  : резерв под игрока (пока что не пригодилось)
// id3  : враждебный моб
// id4  : мирный моб / квест
// id5  : сундук
// id6  : магазин
// id10 : Босс1!!!!!!!!!!!!
// id82 : дверь1
// id83 : дверь2
// id84 : дверь3
// id85 : дверь4
// id86 : дверь5
//
//
//
using System.Security.Cryptography.X509Certificates;

public class Room
{
    protected int _weight;
    protected int _height;
    protected int _xGenPos;
    protected int _yGenPos;
    protected int _roomEvent;
    protected char[,] _roomGraphics;
    protected int[,] _roomObjects;

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
        protected set { _xGenPos = value;}
    }
    public int yGenPos
    {
        get { return _yGenPos; }
        protected set {_yGenPos = value;}
    }
    public int roomEvent
    {
        get { return _roomEvent; }
        protected set {_roomEvent= value;}
    }
    public char[,] roomGraphics
    {
        get { return _roomGraphics; }
        protected set { _roomGraphics = value; }
    }
    public int[,] roomObjects
    {
        get { return _roomObjects; }
        protected set { _roomObjects = value; }
    }
    public static void generateEvent(char[,] Graph, int[,] Objec, int wei, int hei, int roomEve)
    {
        int idkX=new Random().Next(0,wei);
        int idkY=new Random().Next(0, hei);
        int ok = 0;
        while (ok != 1)
        {   
            if (Graph[idkY, idkX] == '.')
            {
                if (roomEve == 3) //монстр
                {
                    Graph[idkY, idkX] = 'e';
                    Objec[idkY, idkX] = 3;
                }
                if (roomEve == 4) //мирный моб / квест
                {
                    Graph[idkY, idkX] = '?';
                    Objec[idkY, idkX] = 4;
                }
                if (roomEve == 5) //сундук
                {
                    Graph[idkY, idkX] = 'с';
                    Objec[idkY, idkX] = 5;
                }
                if (roomEve == 6) //магазин
                {
                    Graph[idkY, idkX] = 'm';
                    Objec[idkY, idkX] = 6;
                }
                if (roomEve == 10) //Босс
                {
                    Graph[idkY, idkX] = 'K';
                    Objec[idkY, idkX] = 10;
                }
                ok = 1;
            }
            idkX=new Random().Next(0,wei);
            idkY = new Random().Next(0, hei);
        }
    }
}

public class Start_room : Room
{

    public Start_room()
    {
        
        weight = _weight=11;
        height = _height=9;
        xGenPos = _xGenPos=0;
        yGenPos = _yGenPos=0;
        roomEvent = _roomEvent=0;
        roomGraphics = _roomGraphics;
        roomObjects= _roomObjects;
    }
       new protected char[,] _roomGraphics =
            {
                { '-','-','-','-','-','-','-','-','-','-','-'},
                { '|','.','.','.','.','.','.','.','.','.','|'},
                { '|','.','.','.','.','.','.','.','.','.','|'},
                { '|','.','.','.','.','.','.','.','.','.','|'},
                { '|','.','.','.','.','.','.','.','.','.','+'},
                { '|','.','.','.','.','.','.','.','.','.','|'},
                { '|','.','.','.','.','.','.','.','.','.','|'},
                { '|','.','.','.','.','.','.','.','.','.','|'},
                { '-','-','-','-','-','-','-','-','-','-','-'}
            };
        new protected int[,] _roomObjects =
        {
            { 0,0,0,0,0,0,0,0,0,0,0},
            { 0,1,1,1,1,1,1,1,1,1,0},
            { 0,1,1,1,1,1,1,1,1,1,0},
            { 0,1,1,1,1,1,1,1,1,1,0},
            { 0,1,1,1,1,1,1,1,1,1,82},
            { 0,1,1,1,1,1,1,1,1,1,0},
            { 0,1,1,1,1,1,1,1,1,1,0},
            { 0,1,1,1,1,1,1,1,1,1,0},
            { 0,0,0,0,0,0,0,0,0,0,0}
        };
    
}

public class Second_room : Room
{
    public Second_room()
    {
        weight=_weight = 15;
        height=_height = 8;
        xGenPos=_xGenPos = 11;
        yGenPos=_yGenPos = 3;
        roomEvent=_roomEvent = new Random().Next(3, 7);
        roomGraphics = _roomGraphics;
        roomObjects= _roomObjects;
        generateEvent(roomGraphics,roomObjects,weight,height, roomEvent);
    }
    new protected char[,] _roomGraphics =
         {
                {'-','-','-','-',' ',' ','-','-','-','-','-','-','-','-','-'},
                {'.','|','.','|',' ',' ','|','.','.','.','.','.','.','.','|'},
                {'.','|','.','|','-','-','|','.','.','.','.','.','.','.','|'},
                {'.','|','.','.','.','.','.','.','.','.','.','.','.','.','|'},
                {'.','.','.','|','-','-','|','.','.','.','.','.','.','.','|'},
                {'-','-','-','-',' ',' ','|','.','.','.','.','.','.','.','|'},
                {' ',' ',' ',' ',' ',' ','|','.','.','.','.','.','.','.','|'},
                {' ',' ',' ',' ',' ',' ','-','-','-','-','+','-','-','-','-'}
            };
    new protected int[,] _roomObjects =
    {
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 1,0,1,0,0,0,0,1,1,1,1,1,1,1,0},
            { 1,0,1,0,0,0,0,1,1,1,1,1,1,1,0},
            { 1,0,1,1,1,1,1,1,1,1,1,1,1,1,0},
            { 1,1,1,0,0,0,0,1,1,1,1,1,1,1,0},
            { 0,0,0,0,0,0,0,1,1,1,1,1,1,1,0},
            { 0,0,0,0,0,0,0,1,1,1,1,1,1,1,0},
            { 0,0,0,0,0,0,0,0,0,0,83,0,0,0,0},
        };

}

public class Third_room : Room
{
    public Third_room()
    {
        weight = _weight = 11;
        height = _height = 10;
        xGenPos = _xGenPos = 14;
        yGenPos = _yGenPos = 11;
        roomEvent = _roomEvent = new Random().Next(3, 7);
        roomGraphics = _roomGraphics;
        roomObjects = _roomObjects;
        generateEvent(roomGraphics, roomObjects, weight, height, roomEvent);
    }
    new protected char[,] _roomGraphics =
         {
                {' ',' ',' ',' ',' ',' ','|','.','|',' ',' '},
                {' ',' ',' ',' ',' ',' ','|','.','|',' ',' '},
                {' ',' ',' ',' ',' ',' ','|','.','|',' ',' '},
                {'-','-','-','-','-','-','-','.','-','-','-'},
                {'|','.','.','.','.','.','.','.','.','.','|'},
                {'|','.','.','.','.','.','.','.','.','.','|'},
                {'+','.','.','.','.','.','.','.','.','.','|'},
                {'|','.','.','.','.','.','.','.','.','.','|'},
                {'|','.','.','.','.','.','.','.','.','.','+'},
                {'-','-','-','-','-','-','-','-','-','-','-'},


            };
    new protected int[,] _roomObjects =
    {
            {0,0,0,0,0,0,0,1,0,0,0},
            {0,0,0,0,0,0,0,1,0,0,0},
            {0,0,0,0,0,0,0,1,0,0,0},
            {0,0,0,0,0,0,0,1,0,0,0},
            {0,1,1,1,1,1,1,1,1,1,0},
            {0,1,1,1,1,1,1,1,1,1,0},
            {84,1,1,1,1,1,1,1,1,1,0},
            {0,1,1,1,1,1,1,1,1,1,0},
            {0,1,1,1,1,1,1,1,1,1,85},
            {0,0,0,0,0,0,0,0,0,0,0}

        };

}
public class Fourth_room : Room
{
    public Fourth_room()
    {
        weight = _weight = 14;
        height = _height = 8;
        xGenPos = _xGenPos = 0;
        yGenPos = _yGenPos = 14;
        roomEvent = _roomEvent = new Random().Next(3, 7);
        roomGraphics = _roomGraphics;
        roomObjects = _roomObjects;
        generateEvent(roomGraphics, roomObjects, weight, height, roomEvent);
    }
    new protected char[,] _roomGraphics =
         {
                {'-','-','-','-','-','-','-','-','-','-','-',' ',' ',' '},
                {'|','.','.','.','.','.','.','.','.','.','|',' ',' ',' '},
                {'|','.','.','.','.','.','.','.','.','.','|','-','-','-'},
                {'|','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                {'|','.','.','.','.','.','.','.','.','.','|','-','-','-'},
                {'|','.','.','.','.','.','.','.','.','.','|',' ',' ',' '},
                {'|','.','.','.','.','.','.','.','.','.','|',' ',' ',' '},
                {'-','-','-','-','-','-','-','-','-','-','-',' ',' ',' '},


            };
    new protected int[,] _roomObjects =
    {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,1,1,1,1,1,1,1,1,1,0,0,0,0},
            {0,1,1,1,1,1,1,1,1,1,0,0,0,0},
            {0,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {0,1,1,1,1,1,1,1,1,1,0,0,0,0},
            {0,1,1,1,1,1,1,1,1,1,0,0,0,0},
            {0,1,1,1,1,1,1,1,1,1,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        };

}

public class Fifth_room : Room
{
    public Fifth_room()
    {
        weight = _weight = 16;
        height = _height = 10;
        xGenPos = _xGenPos = 25;
        yGenPos = _yGenPos = 12;
        roomEvent = _roomEvent = new Random().Next(3, 7);
        roomGraphics = _roomGraphics;
        roomObjects = _roomObjects;
        generateEvent(roomGraphics, roomObjects, weight, height, roomEvent);
    }
    new protected char[,] _roomGraphics =
         {
                {' ',' ',' ',' ',' ',' ','-','-','-','-','+','-','-','-','-','-'},
                {' ',' ',' ',' ',' ',' ','|','.','.','.','.','.','.','.','.','|'},
                {' ',' ',' ',' ',' ',' ','|','.','.','.','.','.','.','.','.','|'},
                {' ',' ',' ',' ',' ',' ','|','.','.','.','.','.','.','.','.','|'},
                {' ',' ',' ',' ',' ',' ','|','.','.','.','.','.','.','.','.','|'},
                {' ',' ',' ',' ',' ',' ','|','.','.','.','.','.','.','.','.','|'},
                {'-','-','-','-','-','-','|','.','.','.','.','.','.','.','.','|'},
                {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','|'},
                {'-','-','-','-','-','-','|','.','.','.','.','.','.','.','.','|'},
                {' ',' ',' ',' ',' ',' ','-','-','-','-','-','-','-','-','-','-'}

            };
    new protected int[,] _roomObjects =
    {
            {0,0,0,0,0,0,0,0,0,0,86,0,0,0,0,0},
            {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0},
            {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0},
            {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0},
            {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0},
            {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0},
            {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
            {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}

        };

}

public class Boss_room : Room
{
    public Boss_room()
    {
        weight = _weight = 13;
        height = _height = 12;
        xGenPos = _xGenPos = 28;
        yGenPos = _yGenPos = 0;
        roomEvent = _roomEvent = 10;
        roomGraphics = _roomGraphics;
        roomObjects = _roomObjects;
        generateEvent(roomGraphics, roomObjects, weight, height, roomEvent);
    }
    new protected char[,] _roomGraphics =
    {
        {'-','-','-','-','-','-','-','-','-','-','-','-','-',},
        {'|','.','.','.','.','.','.','.','.','.','.','.','|',},
        {'|','.','.','.','.','.','.','.','.','.','.','.','|',},
        {'|','.','.','.','.','.','.','.','.','.','.','.','|',},
        {'|','.','.','.','.','.','.','.','.','.','.','.','|',},
        {'|','.','.','.','.','.','.','.','.','.','.','.','|',},
        {'|','.','.','.','.','.','.','.','.','.','.','.','|',},
        {'-','-','-','-','-','-','-','.','-','-','-','-','-',},
        {' ',' ',' ',' ',' ',' ','|','.','|',' ',' ',' ',' ',},
        {' ',' ',' ',' ',' ',' ','|','.','|',' ',' ',' ',' ',},
        {' ',' ',' ',' ',' ',' ','|','.','|',' ',' ',' ',' ',},
        {' ',' ',' ',' ',' ',' ','|','.','|',' ',' ',' ',' ',},
    };

    new protected int[,] _roomObjects =
    {
        {0,0,0,0,0,0,0,0,0,0,0,0,0,},
        {0,1,1,1,1,1,1,1,1,1,1,1,0,},
        {0,1,1,1,1,1,1,1,1,1,1,1,0,},
        {0,1,1,1,1,1,1,1,1,1,1,1,0,},
        {0,1,1,1,1,1,1,1,1,1,1,1,0,},
        {0,1,1,1,1,1,1,1,1,1,1,1,0,},
        {0,1,1,1,1,1,1,1,1,1,1,1,0,},
        {0,0,0,0,0,0,0,1,0,0,0,0,0,},
        {0,0,0,0,0,0,0,1,0,0,0,0,0,},
        {0,0,0,0,0,0,0,1,0,0,0,0,0,},
        {0,0,0,0,0,0,0,1,0,0,0,0,0,},
        {0,0,0,0,0,0,0,1,0,0,0,0,0,}

    };

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
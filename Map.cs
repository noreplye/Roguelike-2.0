using System;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

public class map
{
    private char[,] _map;
    private int weight;
    private int height;
    private char playerTexture = '@';
    private int player_xPos;
    private int player_yPos;
    //map_init

    public map(int _weight,int _height)
    {
        weight= _weight;
        height= _height;
        _map=new char[height,weight];
    }
    public static void init_StartRoom(map current_map) //функция создаёт комнату, в которой игрок появляется изначально
    {
        map.start_room _start_room = new map.start_room();
        int xPos = new Random().Next(0,(current_map.weight-_start_room.weight)); //рандомное местоположение комнаты на карте
        int yPos = new Random().Next(0, (current_map.height - _start_room.height));
        current_map.player_xPos = xPos + new Random().Next(1, _start_room.weight - 2); //рандомный спавн игрока в комнате
        current_map.player_yPos = current_map.height-yPos - new Random().Next(3, _start_room.height - 2);
        // Такое ужасное присваивание потому что у массива индексы вертикальные генерируются сверху вниз, а у координаты "y" снизу вверх
        // а ещё обнаружил, что при Next(1, _start_room.height - 2) мы возможно заспавнимся в границе, поменял на 3 норм стало лень разбираться
        for (int i = yPos; i < yPos+_start_room.height; i++)
        {
            for (int j = xPos; j < xPos + _start_room.weight; j++)
            {
                    current_map._map[i,j]= _start_room._room[i-yPos,j-xPos];
            }
        }
    }



    public static void display(int xPos,int yPos,map current_map) // первые 2 параметра отступ : 1-вправо, 2-вниз
    {
        Console.SetCursorPosition(0, 0);
        Console.Write($"player_xPos:{current_map.player_xPos}, player_yPos:{current_map.player_yPos}, map_height:{current_map.height}, map_weight:{current_map.weight}");
        for (int i = 0; i < current_map.height; i++)
        {
            for (int j=0; j < current_map.weight; j++)
            {
                Console.SetCursorPosition(xPos + j, yPos + i+1);
                Console.Write($"{current_map._map[i, j]}");
            }
            Console.Write("\n");
            Console.SetCursorPosition(xPos + current_map.player_xPos, yPos+ current_map.height - current_map.player_yPos-1);
            Console.ForegroundColor= ConsoleColor.Yellow;//Зависит от расы
            Console.Write($"{current_map.playerTexture}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }


    public static void setpos(map current_map, int _xPos, int _yPos)
    {
        current_map.player_xPos = _xPos;
        current_map.player_yPos = _yPos;
    }
    public static void Move(map current_map, ConsoleKeyInfo _pushed_button)
    {   
        if (_pushed_button.Key == ConsoleKey.LeftArrow)
        {
            current_map.player_xPos -= 1;
        }
        if (_pushed_button.Key == ConsoleKey.RightArrow)
        {
            current_map.player_xPos += 1;
        }
        if (_pushed_button.Key == ConsoleKey.UpArrow)
        {
            current_map.player_yPos += 1;
        }
        if (_pushed_button.Key == ConsoleKey.DownArrow)
        {
            current_map.player_yPos -= 1;
        }
        if (current_map.player_xPos < 0) 
        {
            current_map.player_xPos = 0;
        }
        if (current_map.player_yPos < 0)
        {
            current_map.player_yPos = 0;
        }
        if (current_map.player_yPos >= current_map.height-1)
        {
            current_map.player_yPos = current_map.height-2;
        }
        if (current_map.player_xPos >= current_map.weight)
        {
            current_map.player_xPos = current_map.weight-1;
        }
        if ((current_map._map[current_map.height - 2 - current_map.player_yPos, current_map.player_xPos] == '-') ||
                (current_map._map[current_map.height - 2 - current_map.player_yPos, current_map.player_xPos] == '|'))
        {
            if (_pushed_button.Key == ConsoleKey.LeftArrow)
            {
                current_map.player_xPos += 1;
            }
            if (_pushed_button.Key == ConsoleKey.RightArrow)
            {
                current_map.player_xPos -= 1;
            }
            if (_pushed_button.Key == ConsoleKey.UpArrow)
            {
                current_map.player_yPos -= 1;
            }
            if (_pushed_button.Key == ConsoleKey.DownArrow)
            {
                current_map.player_yPos += 1;
            }
        }

    }

    public class start_room
    {
        public int weight = 11;
        public int height = 9;
        public int room_id = 0;
        public char[,] _room =
        {
            {'-','-','-','-','-','-','-','-','-','-','-'},
            {'|','.','.','.','.','.','.','.','.','.','|'},
            {'|','.','.','.','.','.','.','.','.','.','|'},
            {'|','.','.','.','.','.','.','.','.','.','|'},
            {'|','.','.','.','.','.','.','.','.','.','+'},
            {'|','.','.','.','.','.','.','.','.','.','|'},
            {'|','.','.','.','.','.','.','.','.','.','|'},
            {'|','.','.','.','.','.','.','.','.','.','|'},
            {'-','-','-','-','-','-','-','-','-','-','-'}
        };
    }
}
/*
internal class Program
{
    static void Main(string[] args)
    {
        ConsoleKeyInfo pushed_button;
        int game = 1;
        int interface_otstup = 10;
        map first_level = new map(50, 50);
        map.init_StartRoom(first_level);
        map.display(interface_otstup, interface_otstup, first_level);
        Console.CursorVisible = false;


        while (game > 0)
        {
            map.display(interface_otstup, interface_otstup, first_level);\
            Console.CursorVisible = false;
            pushed_button = Console.ReadKey();
            map.Move(first_level, pushed_button);
        }
    }
}
*/

using System;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

public class map
{
    private char[,] _mapGraphics;
    private int[,] _mapObjects;
    private int weight=50;
    private int height=30;
    private char playerTexture = '@';
    private ConsoleColor playerColour=ConsoleColor.Yellow;
    private int player_xPos;
    private int player_yPos;
    //map_init

    public map()
    {
        _mapGraphics = new char[height, weight];
        _mapObjects = new int[height, weight];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < weight; j++)
            {
                _mapObjects[i, j] = 0;
            }
        }
    }
    public static void init_StartRoom(map current_map) //функция создаёт комнату, в которой игрок появляется изначально (в псевдорандомном месте)
    {
        Room StartRoom = new Start_room();
        current_map.player_xPos =new Random().Next(StartRoom.xGenPos+1, StartRoom.xGenPos-1+StartRoom.weight-1);
        current_map.player_yPos =new Random().Next(StartRoom.yGenPos + 1, StartRoom.yGenPos - 1 + StartRoom.height - 1);
        for (int i = 0; i < StartRoom.height; i++)
        {
            for (int j = 0; j < StartRoom.weight; j++)
            {
                current_map._mapGraphics[StartRoom.yGenPos + i,StartRoom.xGenPos + j] = StartRoom.roomGraphics[i, j];
                current_map._mapObjects[StartRoom.yGenPos + i, StartRoom.xGenPos + j] = StartRoom.roomObjects[i, j];
            }
        }
    }
    public static void init_newRoom(map current_map, Room newRoom)
    {
        for (int i=0; i<newRoom.height; i++)
            {
                for (int j=0; j< newRoom.weight; j++)
                {
                current_map._mapGraphics[newRoom.yGenPos + i, newRoom.xGenPos + j] = newRoom.roomGraphics[i,j];
                current_map._mapObjects[newRoom.yGenPos + i, newRoom.xGenPos + j] = newRoom.roomObjects[i, j];
            }
            }
        
    }
    /*
    public static void spawnmob(map current_map)
    {
        int idkX = new Random().Next(current_map.player_xPos - 1, current_map.player_xPos+2);
        int idkY = new Random().Next(current_map.player_yPos-1, current_map.player_yPos + 2);
        int ok = 0;
        while (ok != 1)
        {
            if (current_map._mapGraphics[idkY, idkX] == '.' && current_map.player_xPos!=idkX && current_map.player_yPos != idkY)
            {
                current_map._mapGraphics[idkY, idkX] = 'e';
                current_map._mapObjects[idkY, idkX] = 3;
                ok = 1;
            }
            idkX = new Random().Next(current_map.player_xPos - 1, current_map.player_xPos + 2);
            idkY = new Random().Next(current_map.player_yPos - 1, current_map.player_yPos + 2);
        }
    }
    */
    public static void init_Event(map current_map)
    {
        if (current_map._mapObjects[current_map.player_yPos, current_map.player_xPos] == 82)
        {
            Room SecondRoom = new Second_room();
            init_newRoom(current_map,SecondRoom);
            current_map._mapObjects[current_map.player_yPos, current_map.player_xPos] = 1;
            current_map._mapGraphics[current_map.player_yPos, current_map.player_xPos] = '.';

        }
        if (current_map._mapObjects[current_map.player_yPos, current_map.player_xPos] == 83)
        {
            Room ThirdRoom = new Third_room();
            init_newRoom(current_map, ThirdRoom);
            current_map._mapObjects[current_map.player_yPos, current_map.player_xPos] = 1;
            current_map._mapGraphics[current_map.player_yPos, current_map.player_xPos] = '.';
        }
        if (current_map._mapObjects[current_map.player_yPos, current_map.player_xPos] == 84)
        {
            Room FourthRoom = new Fourth_room();
            init_newRoom(current_map, FourthRoom);
            current_map._mapObjects[current_map.player_yPos, current_map.player_xPos] = 1;
            current_map._mapGraphics[current_map.player_yPos, current_map.player_xPos] = '.';
        }
        if (current_map._mapObjects[current_map.player_yPos, current_map.player_xPos] == 85)
        {
            Room FifthRoom = new Fifth_room();
            init_newRoom(current_map, FifthRoom);
            current_map._mapObjects[current_map.player_yPos, current_map.player_xPos] = 1;
            current_map._mapGraphics[current_map.player_yPos, current_map.player_xPos] = '.';
        }
        if (current_map._mapObjects[current_map.player_yPos, current_map.player_xPos] == 86)
        {
            Room BossRoom = new Boss_room();
            init_newRoom(current_map, BossRoom);
            current_map._mapObjects[current_map.player_yPos, current_map.player_xPos] = 1;
            current_map._mapGraphics[current_map.player_yPos, current_map.player_xPos] = '.';
        }
        /*int randomic4 = new Random().Next(1,50);
        if (randomic4 == 17|| randomic4 == 34)
        {
            spawnmob(current_map);
        }
        */
    }




    public static void display(int xPos,int yPos,map current_map) // первые 2 параметра отступ : 1-вправо, 2-вниз
    {
        Console.SetCursorPosition(0, 0);
        Console.Write($"player_xPos:{current_map.player_xPos}, player_yPos:{current_map.player_yPos}, map_height:{current_map.height}, map_weight:{current_map.weight}, map_object:{current_map._mapObjects[current_map.player_yPos,current_map.player_xPos]}");
        for (int i = 0; i < current_map.height; i++)
        {
            for (int j=0; j < current_map.weight; j++)
            {
                Console.SetCursorPosition(xPos + j, yPos + i);
                Console.Write($"{current_map._mapGraphics[i, j]}");
                if(i==current_map.player_yPos && j == current_map.player_xPos)
                {
                    Console.SetCursorPosition(xPos + j, yPos + i);
                    Console.ForegroundColor = current_map.playerColour;//Зависит от расы (пока что только в будущем :c )
                    Console.Write($"{current_map.playerTexture}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.Write("\n");
        }
        Console.CursorVisible = false;
    }

    
    public static void setpos(map current_map, int _xPos, int _yPos)
    {
        current_map.player_xPos = _xPos;
        current_map.player_yPos = _yPos;
    }

    public static void Move(map current_map, ConsoleKeyInfo _pushed_button)
    {   
        int prev_x=current_map.player_xPos;
        int prev_y=current_map.player_yPos;
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
            current_map.player_yPos -= 1;
           
        }
        if (_pushed_button.Key == ConsoleKey.DownArrow)
        {
            current_map.player_yPos += 1;
        }
        if (current_map.player_xPos < 0)
        {
            current_map.player_xPos = prev_x;
        }
        if (current_map.player_yPos < 0)
        {
            current_map.player_yPos = prev_y;
        }
        if (current_map.player_xPos >= current_map.weight)
        {
            current_map.player_xPos = prev_x;
        }
        if (current_map.player_yPos >= current_map.height)
        {
            current_map.player_yPos = prev_y;
        }
        if (current_map._mapObjects[current_map.player_yPos, current_map.player_xPos] == 0)
        {
            current_map.player_xPos = prev_x;
            current_map.player_yPos = prev_y;
        }
    }
}

/*

    internal class Program
    {
        static void Main(string[] args)
        {
            int game = 1;

            ConsoleKeyInfo pushed_button;
            map karta = new map();
            map.init_StartRoom(karta);
            Console.WriteLine("Сначала сделайте полный экран (F11).\nЗатем нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
            while (game > 0)
            {
                    map.init_Event(karta);
                    map.display(20, 20, karta);
                    pushed_button = Console.ReadKey();
                    map.Move(karta, pushed_button);
            
            }
        }
    }
}

*/
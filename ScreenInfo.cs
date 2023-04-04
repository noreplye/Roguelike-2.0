using System.Globalization;
using System.Text.Json;
public class ScreenInfo

{
    public const int _SIZE = 10;
    public string[] StringArrayInfo = new string[_SIZE];
    public int count = 0;
    public int status; //
    
    public ScreenInfo(int _status)
    {
        status = _status; //if status == 1 -> it's person info  //  if status == 2 -> it's battle
    }
    public static void StartGreeting()
    {
        StartGame WelcomeGame = new StartGame();
        WelcomeGame = StartGame.StartingGame();
        Console.ReadKey();
        Console.SetCursorPosition(5, 10);
        Console.WriteLine(WelcomeGame._greeting1);
        Console.SetCursorPosition(5, 11);
        Console.WriteLine(WelcomeGame._greeting2);
        Console.SetCursorPosition(5, 12);
        Console.WriteLine(WelcomeGame._greeting3);
        Console.SetCursorPosition(5, 13);
        Console.WriteLine(WelcomeGame._greeting4);
        Console.SetCursorPosition(5, 14);
        Console.WriteLine(WelcomeGame._greeting5);
        Console.SetCursorPosition(5, 15);
        Console.WriteLine(WelcomeGame._greeting6);
        Console.ReadKey();
        Console.SetCursorPosition(57, 18);
        Console.WriteLine(WelcomeGame._present1);
        Console.SetCursorPosition(57, 19);
        Console.WriteLine(WelcomeGame._present2);
        Console.SetCursorPosition(57, 20);
        Console.WriteLine(WelcomeGame._present3);
        Console.SetCursorPosition(57, 21);
        Console.WriteLine(WelcomeGame._present4);
        Console.SetCursorPosition(57, 22);
        Console.WriteLine(WelcomeGame._present5);
        Console.SetCursorPosition(57, 23);
        Console.WriteLine(WelcomeGame._present6);
        
        Console.ReadKey();
		Console.Clear();
    }
    public static void StartNaming()
    {
        StartGame RogueGame = new StartGame();
        RogueGame = StartGame.NamingGame();
        Console.ReadKey();
        Console.SetCursorPosition(73,10);
        Console.WriteLine(RogueGame._rog1);
        Console.SetCursorPosition(73,11);
        Console.WriteLine(RogueGame._rog2);
        Console.SetCursorPosition(73,12);
        Console.WriteLine(RogueGame._rog3);
        Console.ReadKey();

    }

    public static void Menu(int left, int top, int weight, int height)
    {
        for (int j = left; j <= weight + left; j++)
        {
            Console.SetCursorPosition(j, top);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("-");
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(65,16);
            Console.WriteLine("Нажмите любую клавишу, чтобы начать игру");
            Console.SetCursorPosition(j, height + top);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("-");
            
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
        Console.Clear();
    public static void
        ShowLastInfo(ScreenInfo screenInfo) //if status == 1 -> it's person info  //  if status == 2 -> it's battle
    {
        if (screenInfo.status == 1) //Stats info
        {
            for (int i = 0; i < _SIZE; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("                                                                                                         "); //100 пробелов чтобы очистить предыдущую надпись
                Console.SetCursorPosition(0, i);
                Console.Write(screenInfo.StringArrayInfo[i]);
                screenInfo.StringArrayInfo[i] = "";
            }
        }

        if (screenInfo.status == 2) //Battle info
        {
            for (int i = 0; i < _SIZE; i++)
            {
                Console.SetCursorPosition(130, i);
                Console.Write("                                                                                                         "); //100 пробелов чтобы очистить предыдущую надпись
                Console.SetCursorPosition(130, i);
                Console.Write(screenInfo.StringArrayInfo[i]);
                screenInfo.StringArrayInfo[i] = ""; //все показанные строки в массиве почистили
            }
        }

        if (screenInfo.status == 3) //Chest Info
        {
            for (int i = 0; i < _SIZE; i++)
            {
                Console.SetCursorPosition(50, i);
                Console.Write("                                                                                                         "); //100 пробелов чтобы очистить предыдущую надпись
                Console.SetCursorPosition(50, i);
                Console.Write(screenInfo.StringArrayInfo[i]);
                screenInfo.StringArrayInfo[i] = "";
            }
        }

        if (screenInfo.status == 4) //Special Skill Info 
        {
            for (int i = 0; i < _SIZE; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("                                                                                                         "); //100 пробелов чтобы очистить предыдущую надпись
                Console.SetCursorPosition(0, i);
                Console.Write(screenInfo.StringArrayInfo[i]);
                screenInfo.StringArrayInfo[i] = "";
            }
        }
        if (screenInfo.status == 5) //Shop info
        {
            for (int i = 0; i < _SIZE; i++)
            {
                Console.SetCursorPosition(40, i);
                Console.Write("                                                                                                          "); //100 пробелов чтобы очистить предыдущую надпись
                Console.SetCursorPosition(40, i);
                Console.Write(screenInfo.StringArrayInfo[i]);
                screenInfo.StringArrayInfo[i] = "";
            }
        }
        if (screenInfo.status == 6) //Inventory Weapon info
        {
            for (int i = 0; i < _SIZE; i++)
            {
                Console.SetCursorPosition(50, i + 5);
                Console.Write("                                                                                                         "); //100 пробелов чтобы очистить предыдущую надпись
                Console.SetCursorPosition(50, i + 5);
                Console.Write(screenInfo.StringArrayInfo[i]);
                screenInfo.StringArrayInfo[i] = "";
            }
        }
        if (screenInfo.status == 7) //Inventory Armor info
        {
            for (int i = 0; i < _SIZE; i++)
            {
                Console.SetCursorPosition(50, i + 5);
                Console.Write("                                                                                                         "); //100 пробелов чтобы очистить предыдущую надпись
                Console.SetCursorPosition(50, i + 5);
                Console.Write(screenInfo.StringArrayInfo[i]);
                screenInfo.StringArrayInfo[i] = "";
            }
        }
        if (screenInfo.status == 8) // Show Inventory 
        {
            for (int i = 0; i < _SIZE; i++)
            {
                Console.SetCursorPosition(50, i + 5);
                Console.Write("                                                                                                         "); //100 пробелов чтобы очистить предыдущую надпись
                Console.SetCursorPosition(50, i + 5);
                Console.Write(screenInfo.StringArrayInfo[i]);
                screenInfo.StringArrayInfo[i] = "";
            }
        }

        screenInfo.count = 0; // показали и вернулись на первую строку
    }

    public static void AddInfo(string _info, ScreenInfo screenInfo) //if от переполнения
    {
        if (screenInfo.count < _SIZE)
        {
            screenInfo.StringArrayInfo[screenInfo.count] = _info;
            screenInfo.count++;
        }

        if (screenInfo.count >= _SIZE)
        {
            screenInfo.count = 0;
            screenInfo.StringArrayInfo[screenInfo.count] = _info;
        }
    }
}
public class ScreenMenu
{
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
        Console.SetCursorPosition(73,14);
        Console.WriteLine(RogueGame._rog1);
        Console.SetCursorPosition(73,15);
        Console.WriteLine(RogueGame._rog2);
        Console.SetCursorPosition(73,16);
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
            Console.SetCursorPosition(65, 20);
            Console.WriteLine("Нажмите любую клавишу, чтобы начать игру");
            Console.SetCursorPosition(j, height + top);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("-");

        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
        Console.Clear();
    }
    public static void GameWin() // в разработке 
    {
        Console.Clear();
        Winning WinGaming = new Winning();
        WinGaming = Winning.GameWinning();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(73,15);
        Console.WriteLine(WinGaming._win1);
        Console.SetCursorPosition(73,16);
        Console.WriteLine(WinGaming._win2);
        Console.SetCursorPosition(73,17);
        Console.WriteLine(WinGaming._win3);
        Console.ReadKey();
        Console.Clear();
        Console.ReadKey();
    }
    
    public static void GameOver()
    {
        Console.Clear();
        Ending Overing = new Ending();
        Overing = Ending.EndGame();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(73,15);
        Console.WriteLine(Overing._over1);
        Console.SetCursorPosition(73,16);
        Console.WriteLine(Overing._over2);
        Console.SetCursorPosition(73,17);
        Console.WriteLine(Overing._over3);
        Console.ReadKey();
        Console.Clear();
        Console.ReadKey();
    }
}
public class Game
{
    private static Factory GetMyPerson(int ClassSelection) =>
        ClassSelection switch
        {
            1 => new GetKnight(),
            2 => new GerArcher(),
            3 => new GetThief(),
            _ => null
        };
    public static void GameProcess()
    {
        int game = 1;
        ConsoleKeyInfo pushed_button;
        map karta = new map();
        map.init_StartRoom(karta);
        
        Console.SetCursorPosition(65,16);
        Console.Write("Введите имя вашего персонажа: ");
        Console.ForegroundColor = ConsoleColor.Green;
        string name = Console.ReadLine();
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(65,18);
        Console.WriteLine("Выберите класс вашего персонажа: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(65,19);
        Console.WriteLine("1. Рыцарь");
        Console.SetCursorPosition(65,20);
        Console.WriteLine("2. Лучник");
        Console.SetCursorPosition(65,21);
        Console.WriteLine("3. Вор");
        int ClassSelection = Convert.ToInt32(Console.ReadLine());
        Console.ForegroundColor = ConsoleColor.White;        
        
        Factory factory = GetMyPerson(ClassSelection);
        Person character = factory.GetMyPerson();
        character.TakeName(name);
        //character.ShowStats();
        Console.Clear();
            
        while (game > 0)
        {
            map.init_Event(karta, character);
            map.display(50, 20, karta);
            Console.SetCursorPosition(0, 1);
            character.ShowStats();
            pushed_button = Console.ReadKey();
            Game_control.button_control(karta, pushed_button, character);
            map.display(50, 20, karta);
            if (character.Health <= 0)
            {
                Console.Clear();
                //Console.WriteLine("GAME OVER");
                game = 0;
            }
        }
    }
}
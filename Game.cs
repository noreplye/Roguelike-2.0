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
        Console.Write("");
        Console.Write("Введите имя вашего персонажа: ");
        string name = Console.ReadLine();
        Console.WriteLine("Выберите класс вашего персонажа: \n 1. Рыцарь \n 2. Лучник \n 3. Вор\n");
        int ClassSelection = Convert.ToInt32(Console.ReadLine());
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
                Console.WriteLine("GAME OVER");
                game = 0;
            }
        }
    }
}
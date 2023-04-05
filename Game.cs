using static Program;

public class Game
{
    private static Factory GetMyPerson(ConsoleKeyInfo ClassSelection) =>
        ClassSelection.Key switch
        {
            ConsoleKey.D1 => new GetKnight(),
            ConsoleKey.D2 => new GerArcher(),
            ConsoleKey.D3 => new GetThief(),
            _ => null
        };
    public static void GameProcess()
    {
        ConsoleKeyInfo pushed_button;
        map karta = new map();
        map.init_StartRoom(karta);
        Console.SetCursorPosition(65,16);
        Console.Write("Введите имя вашего персонажа: ");
        Console.ForegroundColor = ConsoleColor.Green;
        string name = Console.ReadLine();
        if (name.Length > 15) { name = name.Substring(0, 15); }
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
        ConsoleKeyInfo ClassSelection = Console.ReadKey();
        while(ClassSelection.Key!=ConsoleKey.D1 && ClassSelection.Key != ConsoleKey.D2 && ClassSelection.Key != ConsoleKey.D3)
        {
            ClassSelection = Console.ReadKey();
        }
        Console.ForegroundColor = ConsoleColor.White;
        Factory factory = GetMyPerson(ClassSelection);
        Person character = factory.GetMyPerson();
        character.TakeName(name);
        if (GameSettings.Game_Settings().isOp == 1)
        {
            character.inventory.equippedWeapon = new Weapon(1, 1, GameSettings.Game_Settings().OpWeaponStats, GameSettings.Game_Settings().OpWeaponName, 1);
            character.inventory.equippedArmor = new Armor(1, GameSettings.Game_Settings().OpArmorStats, GameSettings.Game_Settings().OpArmorName, 1);
            character.PutOnWeapon(character.inventory.equippedWeapon.ItemStats);
            character.PutOnArmor(character.inventory.equippedArmor.ItemStats);
            character.inventory.Money = GameSettings.Game_Settings().OpMoney;
            character.inventory.Heal = GameSettings.Game_Settings().OpHeal;
        }
        //character.ShowStats();
        Console.Clear();
        map.display(50, 20, karta);
        character.ShowStats();
        pushed_button = Console.ReadKey();
        while (1 > 0)
        {
            map.display(50, 20, karta);
            character.ShowStats();
            map.init_Event(karta, character);
            pushed_button = Console.ReadKey();
            Game_control.button_control(karta, pushed_button, character);
            if (character.Health <= 0)
            {
                Console.Clear();
                ScreenMenu.GameOver();
                //Console.WriteLine("GAME OVER");
                return;
            }
        }
    }
}
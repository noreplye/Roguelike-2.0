public class Inventory
{
    public Armor equippedArmor= new Armor(0, 0, "Свободная ячейка под броню", 0);
    public Weapon equippedWeapon=new Weapon(0, 0, 0, "Свободная ячейка под оружие", 0);
    public Armor inventoryArmor = new Armor(0, 0, "Свободная ячейка под броню", 0);
    public Weapon inventoryWeapon = new Weapon(0, 0, 0, "Свободная ячейка под оружие", 0);
    public int Heal=1;
    public int Money=0;

    public static void GetItemWeapon(Person character, Weapon _weapon)
    {
        ConsoleKeyInfo _pushed_button;
        if (character.inventory.inventoryWeapon.Id == 0)
        {
            Console.WriteLine("");
            Console.WriteLine("1-Положить в инвентарь. 2-Взять вместо основного. 3-Не брать");
            _pushed_button = Console.ReadKey();
            while (1 == 1)
            {
                if (_pushed_button.Key == ConsoleKey.D1)
                {
                    character.inventory.inventoryWeapon = _weapon;
                    return;
                }
                if (_pushed_button.Key == ConsoleKey.D2)
                {
                    character.inventory.inventoryWeapon = character.inventory.equippedWeapon;
                    character.TakeOfWeapon(character.inventory.equippedWeapon.ItemStats);
                    character.inventory.equippedWeapon = _weapon;
                    character.PutOnWeapon(character.inventory.equippedWeapon.ItemStats);
                    return;
                }
                if (_pushed_button.Key == ConsoleKey.D3)
                {
                    return;
                }
                _pushed_button = Console.ReadKey();
            }

        }
        if (character.inventory.inventoryWeapon.Id != 0)
        {
            Console.WriteLine("");
            Console.WriteLine("1-Положить в инвентарь с заменой. 2-Взять вместо основного. 3-Не брать");
            _pushed_button = Console.ReadKey();
            while (1 == 1)
            {
                if (_pushed_button.Key == ConsoleKey.D1)
                {
                    character.inventory.inventoryWeapon = _weapon;
                    return;
                }
                if (_pushed_button.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Куда основное? 1-Выбросить. 2-Оставить");
                    while (1 == 1)
                    {
                        _pushed_button = Console.ReadKey();
                        if (_pushed_button.Key == ConsoleKey.D1)
                        {
                            character.TakeOfWeapon(character.inventory.equippedWeapon.ItemStats);
                            character.inventory.equippedWeapon = _weapon;
                            character.PutOnWeapon(character.inventory.equippedWeapon.ItemStats);
                            return;
                        }
                        if (_pushed_button.Key == ConsoleKey.D2)
                        {
                            character.TakeOfWeapon(character.inventory.equippedWeapon.ItemStats);
                            character.inventory.inventoryWeapon = character.inventory.equippedWeapon;
                            character.inventory.equippedWeapon = _weapon;
                            character.PutOnWeapon(character.inventory.equippedWeapon.ItemStats);
                            return;
                        }
                    }
                }
                if (_pushed_button.Key == ConsoleKey.D3)
                {
                    return;
                }
                _pushed_button = Console.ReadKey();
            }
        }
    }
    
    public static void GetItemArmor(Person character, Armor _armor)
    {
        ConsoleKeyInfo _pushed_button;
        if (character.inventory.inventoryArmor.Type == 0)
        {
            Console.WriteLine(" ");
            Console.WriteLine("1-Положить в инвентарь. 2-Взять вместо основного. 3-Не брать");
            _pushed_button = Console.ReadKey();
            while (1 == 1)
            {
                if (_pushed_button.Key == ConsoleKey.D1)
                {
                    character.inventory.inventoryArmor = _armor;
                    return;
                }
                if (_pushed_button.Key == ConsoleKey.D2)
                {
                    character.inventory.inventoryArmor = character.inventory.equippedArmor;
                    character.TakeOfArmor(character.inventory.equippedArmor.ItemStats);
                    character.inventory.equippedArmor = _armor;
                    character.PutOnArmor(character.inventory.equippedArmor.ItemStats);
                    return;
                }
                if (_pushed_button.Key == ConsoleKey.D3)
                {
                    return;
                }
                _pushed_button = Console.ReadKey();
            }
        }
        if (character.inventory.inventoryArmor.Type != 0)
        {
            Console.WriteLine(" ");
            Console.WriteLine("1-Положить в инвентарь с заменой. 2-Взять вместо основного. 3-Не брать");
            _pushed_button = Console.ReadKey();
            while (1 == 1)
            {
                if (_pushed_button.Key == ConsoleKey.D1)
                {
                    character.inventory.inventoryArmor = _armor;
                    return;
                }
                if (_pushed_button.Key == ConsoleKey.D2)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Куда основное? 1-Выбросить. 2-Оставить");
                    while (1 == 1)
                    {
                        _pushed_button = Console.ReadKey();
                        if (_pushed_button.Key == ConsoleKey.D1)
                        {
                            character.TakeOfArmor(character.inventory.equippedArmor.ItemStats);
                            character.inventory.equippedArmor = _armor;
                            character.PutOnArmor(character.inventory.equippedArmor.ItemStats);
                            return;
                        }
                        if (_pushed_button.Key == ConsoleKey.D2)
                        {
                            character.TakeOfArmor(character.inventory.equippedArmor.ItemStats);
                            character.inventory.inventoryArmor = character.inventory.equippedArmor;
                            character.inventory.equippedArmor = _armor;
                            character.PutOnArmor(character.inventory.equippedArmor.ItemStats);
                            return;
                        }
                    }
                }
                if (_pushed_button.Key == ConsoleKey.D3)
                {
                    return;
                }
                _pushed_button = Console.ReadKey();
            }
        }
    }

    public static void GetHeal(Inventory inventory)
    {
        inventory.Heal+= 1;
    }
    public static void GetMoney(Inventory inventory)
    {
        inventory.Money += 1;
    }
    
    public static void LostMoneyWeapon(Inventory inventory, Weapon ShopWeapon)
    {
        inventory.Money -= ShopWeapon.ItemCost;
    }

    public static void LostMoneyArmor(Inventory inventory, Armor ShopArmor) 
    { 
        inventory.Money -= ShopArmor.ItemCost;
    }
    public static void SwapWeapon(Person character,Inventory inventory)
    {
        Weapon weapon = inventory.inventoryWeapon;
        character.TakeOfWeapon(inventory.equippedWeapon.ItemStats);
        inventory.inventoryWeapon = inventory.equippedWeapon;
        inventory.equippedWeapon = weapon;
        character.PutOnWeapon(inventory.equippedWeapon.ItemStats);
    }
    public static void SwapArmor(Person character, Inventory inventory)
    {
        Armor armor = inventory.inventoryArmor;
        character.TakeOfArmor(inventory.equippedArmor.ItemStats);
        inventory.inventoryArmor = inventory.equippedArmor;
        inventory.equippedArmor = armor;
        character.PutOnArmor(inventory.equippedArmor.ItemStats);
    }

    public static void show_inventory(Person character)
    {
        Console.SetCursorPosition(50, 0);
        Console.WriteLine("                                                            ");
        Console.SetCursorPosition(50, 0);
        Console.WriteLine("Выйти из инвентаря: (i) | Выпить зелье: (q)");
        Console.SetCursorPosition(50, 1);
        Console.WriteLine("                                                            ");
        Console.SetCursorPosition(50, 1);
        Console.WriteLine("Сменить броню: (w) | Сменить оружие: (e)");
        Console.SetCursorPosition(50, 2);
        Console.WriteLine("                                                            ");
        Console.SetCursorPosition(50, 2);
        Console.Write($"У вас:{character.inventory.Money} монеты,{character.inventory.Heal} зелья.");
        Console.SetCursorPosition(50, 3);
        Console.WriteLine("                                                            ");
        Console.SetCursorPosition(50, 3);
        Console.WriteLine("Инвентарь:");
        Console.SetCursorPosition(50, 4);
        Console.WriteLine("                                                            ");
        Console.SetCursorPosition(50, 4);
        Console.WriteLine($"{character.inventory.inventoryArmor.ItemName},броня:{character.inventory.inventoryArmor.ItemStats}. Выбросить: (a)");
        Console.SetCursorPosition(50, 5);
        Console.WriteLine("                                                            ");
        Console.SetCursorPosition(50, 5);
        Console.WriteLine($"{character.inventory.inventoryWeapon.ItemName},урон:{character.inventory.inventoryWeapon.ItemStats}. Выбросить: (s)");
        Console.SetCursorPosition(50, 6);
        Console.WriteLine("                                                            ");
        Console.SetCursorPosition(50, 6);
        Console.WriteLine("Надето:");
        Console.SetCursorPosition(50, 7);
        Console.WriteLine("                                                            ");
        Console.SetCursorPosition(50, 7);
        Console.WriteLine($"{character.inventory.equippedArmor.ItemName},броня:{character.inventory.equippedArmor.ItemStats}.");
        Console.SetCursorPosition(50, 8);
        Console.WriteLine("                                                            ");
        Console.SetCursorPosition(50, 8);
        Console.WriteLine($"{character.inventory.equippedWeapon.ItemName},урон:{character.inventory.equippedWeapon.ItemStats}.");

    }
}


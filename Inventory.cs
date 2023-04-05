public class Inventory
{   
    public Armor equippedArmor = new Armor(0, 0, "Свободная ячейка под броню", 0);
    public Weapon equippedWeapon = new Weapon(0, 0, 0, "Свободная ячейка под оружие", 0);
    public Armor inventoryArmor = new Armor(0, 0, "Свободная ячейка под броню", 0);
    public Weapon inventoryWeapon = new Weapon(0, 0, 0, "Свободная ячейка под оружие", 0);
    public int Heal = 1;
    public int Money = 0;

    public static void GetItemWeapon(Person character, Weapon _weapon)
    {
        ConsoleKeyInfo _pushed_button;
        ScreenInfo InventoryWeaponInfo = new ScreenInfo(6);
        if (character.inventory.inventoryWeapon.Id == 0)
        {
            ScreenInfo.AddInfo("1-Положить в инвентарь. 2-Взять вместо основного. 3-Не брать", InventoryWeaponInfo);
            ScreenInfo.ShowLastInfo(InventoryWeaponInfo);
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
            ScreenInfo.AddInfo("1-Положить в инвентарь с заменой. 2-Взять вместо основного. 3-Не брать", InventoryWeaponInfo);
            ScreenInfo.ShowLastInfo(InventoryWeaponInfo);
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
                    ScreenInfo.AddInfo("Куда основное? 1-Выбросить. 2-Оставить", InventoryWeaponInfo);
                    ScreenInfo.ShowLastInfo(InventoryWeaponInfo);
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
        ScreenInfo InventoryArmorInfo = new ScreenInfo(7);
        if (character.inventory.inventoryArmor.Type == 0)
        {
            ScreenInfo.AddInfo("1-Положить в инвентарь. 2-Взять вместо основного. 3-Не брать", InventoryArmorInfo);
            ScreenInfo.ShowLastInfo(InventoryArmorInfo);
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
            ScreenInfo.AddInfo("1-Положить в инвентарь с заменой. 2-Взять вместо основного. 3-Не брать", InventoryArmorInfo);
            ScreenInfo.ShowLastInfo(InventoryArmorInfo);
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
                    ScreenInfo.AddInfo("Куда основное? 1-Выбросить. 2-Оставить", InventoryArmorInfo);
                    ScreenInfo.ShowLastInfo(InventoryArmorInfo);
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
        inventory.Heal += 1;
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

    public static void SwapWeapon(Person character, Inventory inventory)
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
        ScreenInfo ShowInventory = new ScreenInfo(8);
        ScreenInfo.AddInfo("Выйти из инвентаря: (i) | Выпить зелье: (q)", ShowInventory);
        ScreenInfo.AddInfo("Сменить броню: (w) | Сменить оружие: (e)", ShowInventory);
        ScreenInfo.AddInfo($"У вас:{character.inventory.Money} монеты,{character.inventory.Heal} зелья.", ShowInventory);
        ScreenInfo.AddInfo("Инвентарь:", ShowInventory);
        ScreenInfo.AddInfo($"{character.inventory.inventoryArmor.ItemName},броня:{character.inventory.inventoryArmor.ItemStats}. Выбросить: (a)", ShowInventory);
        ScreenInfo.AddInfo($"{character.inventory.inventoryWeapon.ItemName},урон:{character.inventory.inventoryWeapon.ItemStats}. Выбросить: (s)", ShowInventory);
        ScreenInfo.AddInfo("Надето:", ShowInventory);
        ScreenInfo.AddInfo($"{character.inventory.equippedArmor.ItemName},броня:{character.inventory.equippedArmor.ItemStats}.", ShowInventory);
        ScreenInfo.AddInfo($"{character.inventory.equippedWeapon.ItemName},урон:{character.inventory.equippedWeapon.ItemStats}.", ShowInventory);
        ScreenInfo.ShowLastInfo(ShowInventory);
    }
}
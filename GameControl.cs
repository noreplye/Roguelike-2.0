public class Game_control
{
    public static void button_control(map karta, ConsoleKeyInfo pushed_button, Person character)
    {
        if (pushed_button.Key == ConsoleKey.I || pushed_button.Key == ConsoleKey.DownArrow || pushed_button.Key == ConsoleKey.UpArrow || pushed_button.Key == ConsoleKey.LeftArrow || pushed_button.Key == ConsoleKey.RightArrow)
        {
            map.Move(karta, pushed_button);
            if (pushed_button.Key == ConsoleKey.I)
            {
                Inventory.show_inventory(character);
                while (1 == 1)
                {
                    pushed_button = Console.ReadKey();
                    if (pushed_button.Key == ConsoleKey.I)
                    {
                        break;
                    }
                    if (pushed_button.Key == ConsoleKey.E)
                    {
                        Inventory.SwapWeapon(character, character.inventory);

                        Inventory.show_inventory(character);
                    }
                    if (pushed_button.Key == ConsoleKey.W)
                    {
                        Inventory.SwapArmor(character, character.inventory);
                        Inventory.show_inventory(character);
                    }
                    if (pushed_button.Key == ConsoleKey.Q)
                    {
                        character.DrinkHeal();
                        Inventory.show_inventory(character);
                    }
                    if (pushed_button.Key == ConsoleKey.A)
                    {
                        character.inventory.inventoryArmor = new Armor(0, 0, "Свободная ячейка под броню", 0);
                        Inventory.show_inventory(character);
                    }
                    if (pushed_button.Key == ConsoleKey.S)
                    {
                        character.inventory.inventoryWeapon= new Weapon(0, 0, 0, "Свободная ячейка под оружие", 0);
                        Inventory.show_inventory(character);
                    }

                }
                Console.Clear();
            }
            map.enemyMoving(karta, 'e', 3);
            map.enemyMoving(karta, 'K', 10);
        }
        if (pushed_button.Key == ConsoleKey.Spacebar)
        {
            Console.Clear();
        }
    }
}


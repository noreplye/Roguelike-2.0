abstract class Factory
{
    public abstract Person GetMyPerson();
}

class GetKnight : Factory
{
    public override Person GetMyPerson()
    {
        Knight knight = new(200, 80, 100, 0, 1, "");
        return knight;
    }


}

class GerArcher : Factory
{
    public override Person GetMyPerson()
    {
        Archer archer = new(20, 111, 100, 0, 2, "");
        return archer;
    }


}

class GetThief : Factory
{
    public override Person GetMyPerson()
    {
        Thief thief = new(122, 122, 122, 0, 3, "");
        return thief;
    }


}
public class Person
{
    public float _damage;
    private float _stamina;
    public float _health;
    private string _name;
    public float _armor;
    private int _WeaponId;
    public int _SpellCounter = 0;

    public Inventory inventory;


    public Person(float damage, float stamina, float health, float armor, int weapon, string name)
    {
        _damage = damage;
        _stamina = stamina;
        _health = health;
        _armor = armor;
        _name = name;
        _WeaponId = weapon;
        inventory = new Inventory();
        
    }

    public void ShowStats()
    {
        Console.WriteLine($"Вашего персонажа зовут: {_name}\nВаши характеристики:\nУрон = {_damage}\nБроня = " +
            $"{_armor}\nВыносливость = {_stamina}\nЗдоровье = {_health}");
    }
    public float Health => _health;
    public float Stamina => _stamina;
    public string Name => _name;
    public float Damage => _damage;
    public float Armor => _armor;
    public void TakeName(string name)
    {
        _name = name;
    }
    public void DrinkHeal()
    {
        inventory.Heal -= 1;
        _health = _health + 30;
        if (_health > 100) { _health = 100; }
    }
    public void StaminaChanges(int changes)
    {
        _stamina = _stamina + changes;
    }
    public void TakeDamage(float EnemyDamage)
    {
        _health = _health - (EnemyDamage * (1-(_armor / 100)));
    }

    public void PutOnWeapon(int ItemStats)
    {
        _damage = _damage + ItemStats;
        //Console.WriteLine($"Ваш урон: {_damage}");
    }

    public void TakeOfWeapon(int ItemStats)
    {
        _damage = _damage - ItemStats;
        //Console.WriteLine($"Ваш урон: {_damage}");
    }
    public void PutOnArmor(int ItemStats)
    {
        _armor = _armor + ItemStats;
        //Console.WriteLine($"Ваш урон: {_damage}");
    }
    public void TakeOfArmor(int ItemStats)
    {
        _armor = _armor - ItemStats;
        //Console.WriteLine($"Ваша броня: {_armor}");
    }

    public void BlockDamage(float EnemyDamage)
    {
        _health = _health - EnemyDamage * 0.5f -
        (EnemyDamage *0.5f*(1-(_armor / 100)));
        _stamina += 10;
    }
    virtual public void SpecialSkill()
    {
        _SpellCounter++;
    }
    virtual public void ReturnSpell()
    {

    }
    public static void Battle(Person character, int rnd)
    {
        int stam;
        bool battle = false;
        Person[] enemys =
        {
            new Person(5, 50, 50, 50, 1, "орк"),
            new Person(7, 60, 70, 50, 1, "троль"),
            new Person(3, 30, 30, 50, 1, "слайм"),
            new Person(10, 50, 100, 50, 1, "Ким"),
        };

        Console.Write($"\nВаше здоровье: {character.Health}\nЗдоровье противника {enemys[rnd].Name}: {enemys[rnd].Health}\n");
        ConsoleKeyInfo Selection;
        character.ReturnSpell();

        while (character.Health > 0 && enemys[rnd].Health > 0)
        {
            //Console.WriteLine($"\n\n{character.Armor}\n{character._SpellCounter}\n\n");
            Console.WriteLine("На вас напали! Выпить зелье перед ходом(1) или перейти к ходу(2)?");
            Selection = Console.ReadKey();
            while (Selection.Key != ConsoleKey.D2)
            { 
                    if ((Selection.Key == ConsoleKey.D1)&&( character.inventory.Heal > 0))
                    {
                        character.DrinkHeal();
                    }
                //Console.WriteLine($"\n\n{character.Armor}\n{character._SpellCounter}\n\n");
                Console.Write($"\nВаше здоровье: {character.Health}\nЗдоровье противника {enemys[rnd].Name}: {enemys[rnd].Health}\n");
                Console.WriteLine("На вас напали! Выпить зелье перед ходом(1) или перейти к ходу(2)?");
                Selection = Console.ReadKey();
            }
            if (Selection.Key == ConsoleKey.D2)
            {   
                Console.WriteLine("\nКакое действие вы выберите?\nАтака - 1\nБлокировать атаку врага - 2\nСпециальная способность - 3");
                Selection = Console.ReadKey();
                while (battle == false)
                {

                    if (Selection.Key == ConsoleKey.D1)
                    {
                        if (character.Stamina > 19)
                        {
                            stam = -20;
                            character.StaminaChanges(stam);
                            enemys[rnd].TakeDamage(character.Damage);
                        }
                        else
                        {
                            Console.WriteLine("\nУ вас недостаточно Выносливости! Вы пытаетесь попасть по врагу, но промахиваетесь! Враг вас атаковал!\n");
                        }
                    }
                    if (Selection.Key == ConsoleKey.D2)
                    {
                        stam = 10;
                        character.BlockDamage(enemys[rnd].Damage);
                        character.StaminaChanges(stam);
                    }
                    if (Selection.Key == ConsoleKey.D3)
                    {
                        if (character.Stamina > 49)
                        {
                            stam = -50;
                            character.StaminaChanges(stam);
                            character.SpecialSkill();
                        }
                        else
                        {
                            Console.WriteLine("\nУ вас недостаточно Выносливости! Вы пытаетесь скастовать способность, но у вас ничего не вышло! Враг вас атаковал!\n");
                        }
                    }
                    Console.Write("\n");
                    character.ShowStats();
                    Console.WriteLine($"\nВаше здоровье: {character.Health}\nЗдоровье противника {enemys[rnd].Name}: {enemys[rnd].Health}\n");
                    character.TakeDamage(enemys[rnd].Damage);
                    if (character.Health <= 0)
                    {
                        Console.WriteLine("Вы умерли");
                        battle = true;
                        break;
                    }
                    if (enemys[rnd].Health <= 0)
                    {
                        character.ReturnSpell();
                        Console.WriteLine("\nВы победили\n");
                        battle = true;
                        break;
                    }
                    Console.WriteLine("\nКакое действие вы выберите?\nАтака - 1\nБлокировать атаку врага - 2\nСпециальная способность - 3\n");
                    Selection = Console.ReadKey();
                }
            }
            Console.WriteLine($"\nВаше здоровье: {character.Health}\nВаша выносливость: {character.Stamina}\nЗдоровье противника {enemys[rnd].Name}: {enemys[rnd].Health}\n");
        }
    }

    public static void OpenChest(Person character)
    {
        int pox = 0;
        int poy = 45;
        int toget = new Random().Next(0, 4); // 0 - монетка, 1 - фласка, 2 - броня, 3 - оружие
        if (toget == 3)
        {
            Console.SetCursorPosition(pox, poy);
            int index=0;
            Weapon[] weapon = 
            {
                new Weapon(1,0, 2, "дубовая палка", 10 ),
                new Weapon(1,0, 2, "Ржавая труба", 15),
                new Weapon(1,0,2, "Кочерга", 20),
                new Weapon(1,0,8, "Арматура", 20),
                new Weapon(1,0,8, "Меч", 20),
                new Weapon(1,0,1000, "Меч короля Артура", 2890),
                new Weapon(2,1 ,2, "Рогатка-1", 10),
                new Weapon(2,1 ,2, "Рогатка-2", 10),
                new Weapon(2,1 ,2, "Рогатка-3", 10),
                new Weapon(2,1 ,8, "Рогатка-4", 10),
                new Weapon(2,1 ,8, "Лук 5 уровоня", 15),
                new Weapon(2,1 ,1240, "Лук 6 уровоня", 20),
                new Weapon(3,2 ,2, "Зубочистка 1 уровня", 10),
                new Weapon(3,2 ,2, "Зубочистка 2 уровня", 10),
                new Weapon(3,2 ,2, "Зубочистка 3 уровня", 10),
                new Weapon(3,2 ,8, "Зубочистка 4 уровня", 10),
                new Weapon(3,2 ,8, "Зубочистка 5 уровня", 15),
                new Weapon(3,2 ,190201, "Зубочистка 6 уровня", 20)

            };
            if (character._WeaponId == 1)
            {
                index=new Random().Next(0, 6);
            }
            if (character._WeaponId == 2)
            {
                index = new Random().Next(6, 12);
            }
            if (character._WeaponId == 3)
            {
                index = new Random().Next(12, 18);
            }
            Weapon WeaponToGet = weapon[index];
            Console.SetCursorPosition(pox, poy);
            Console.WriteLine("                                                           ");
            Console.SetCursorPosition(pox, poy);
            Console.WriteLine($"Вам выпало {WeaponToGet.ItemName} - Урон:{WeaponToGet.ItemStats},Стоимость:{WeaponToGet.ItemCost}");
            Inventory.GetItemWeapon(character, WeaponToGet);
            Console.Clear();
        }
        if (toget == 2)
        {
            int index = 0;
            Armor[] armor =
            {
                new Armor (3, 5, "Картон - 1", 10),
                new Armor (3, 6, "Картон - 2", 11),
                new Armor (3, 7, "Картон - 3", 12),
                new Armor (4, 8, "Резиновая подстилка - 1", 13),
                new Armor (4, 9, "Резиновая подстилка - 2", 14),
                new Armor (4, 10, "Резиновая подстилка - 3", 15),
                new Armor (5, 11, "Кульчуга - 1", 16),
                new Armor (5, 12, "Кульчуга - 2", 17),
                new Armor (5, 13, "Кульчуга - 3", 18),

            };
            index =new Random().Next(0,armor.Length);
            Armor ArmorToGet = armor[index];
            Console.SetCursorPosition(pox, poy);
            Console.WriteLine("                                                           ");
            Console.SetCursorPosition(pox, poy);
            Console.WriteLine($"Вам выпало {ArmorToGet.ItemName} - Броня:{ArmorToGet.ItemStats},Стоимость:{ArmorToGet.ItemCost}");
            Inventory.GetItemArmor(character, ArmorToGet);
            Console.Clear();
        }
        if (toget == 0)
        {
            Console.SetCursorPosition(pox, poy);
            Console.WriteLine("                                                           ");
            Console.SetCursorPosition(pox, poy);
            Console.WriteLine("Вам выпала монетка");
            Inventory.GetMoney(character.inventory);
        }
        if (toget == 1)
        {
            Console.SetCursorPosition(pox, poy);
            Console.WriteLine("                                                           ");
            Console.SetCursorPosition(pox, poy);
            Console.WriteLine("Вам выпало зелье здоровья");
            Inventory.GetHeal(character.inventory);
        }
    }
    public static void Shop(Person character)
    {
        Armor[] armor =
          {
                new Armor (3, 5, "Картон - 1", 10),
                new Armor (3, 6, "Картон - 2", 11),
                new Armor (3, 7, "Картон - 3", 12),
                new Armor (4, 8, "Резиновая подстилка - 1", 13),
                new Armor (4, 9, "Резиновая подстилка - 2", 14),
                new Armor (4, 10, "Резиновая подстилка - 3", 15),
                new Armor (5, 11, "Кульчуга - 1", 16),
                new Armor (5, 12, "Кульчуга - 2", 17),
                new Armor (5, 13, "Кульчуга - 3", 18),
            };
        Weapon[] weapon =
            {
                new Weapon(1,0, 2, "дубовая палка", 10 ),
                new Weapon(1,0, 2, "Ржавая труба", 15),
                new Weapon(1,0,2, "Кочерга", 20),
                new Weapon(1,0,8, "Арматура", 20),
                new Weapon(1,0,8, "Меч", 20),
                new Weapon(1,0,1000, "Меч короля Артура", 2890),
                new Weapon(2,1 ,2, "Рогатка-1", 10),
                new Weapon(2,1 ,2, "Рогатка-2", 10),
                new Weapon(2,1 ,2, "Рогатка-3", 10),
                new Weapon(2,1 ,8, "Рогатка-4", 10),
                new Weapon(2,1 ,8, "Лук 5 уровоня", 15),
                new Weapon(2,1 ,1240, "Лук 6 уровоня", 20),
                new Weapon(3,2 ,2, "Зубочистка 1 уровня", 10),
                new Weapon(3,2 ,2, "Зубочистка 2 уровня", 10),
                new Weapon(3,2 ,2, "Зубочистка 3 уровня", 10),
                new Weapon(3,2 ,8, "Зубочистка 4 уровня", 10),
                new Weapon(3,2 ,8, "Зубочистка 5 уровня", 15),
                new Weapon(3,2 ,190201, "Зубочистка 6 уровня", 20)
            };
        Random rand = new Random();
        int index = new Random().Next(0, armor.Length);
        int index1 = new Random().Next(0, weapon.Length);
        int select = 0;
        Console.WriteLine($"Приветствую тебя, добрый путник {character.Name}, в самом лучшем и единственном магазине во всем подзимелье!\n" +
                          $"Лучшем, потому что нет аналогов! Единственном, потому что только я не боюсь этоих мест!\nЧего ты желаешь?\n" +
                          $"\'1\' - купить предмет\n\'2\' - продать предмет\n\'3\' - покинуть магазин\n(Если вы покините магазин, то не сможете вернуться в его на этом уровне\n)");
        while (select != 3)
        {
            select = Convert.ToInt32(Console.ReadLine());
            if (select == 3) break;
            if (select == 1)
            {
                int selectBUY = 0;
                Armor ShopArmor = armor[index];
                Weapon ShopWeapon = weapon[index];
                Console.WriteLine($"Ого! {character.Name}, вам очень повезло! Сегодня в ассортименте:\n" +
                    $"Броня: {ShopArmor.ItemName} - защита:{ShopArmor.ItemStats}, цена:{ShopArmor.ItemCost}\n" +
                    $"Оружие: {ShopWeapon.ItemName} - защита:{ShopWeapon.ItemStats}, цена:{ShopWeapon.ItemCost}\n" +
                    $"Желаете что-нибудь приобрести?\n \'1\' - броню\n\'2\' - оружие\n\'3\' - воздержусь\n");
                while (selectBUY != 4)
                {
                    if (selectBUY == 4) break;
                    selectBUY = Convert.ToInt32(Console.ReadLine());
                    if (selectBUY == 1 && (character.inventory.Money > ShopWeapon.Cost))
                    {
                        Inventory.GetItemArmor(character, ShopArmor);
                        Inventory.LostMoneyWeapon(character.inventory, ShopWeapon);
                        selectBUY = 4;
                    }
                    else
                    {
                        Console.WriteLine($"У вас недостаточно монет!\n" +
                            $"У вас: {character.inventory.Money} Цена: {ShopWeapon.Cost}\n");
                    }
                    if (selectBUY == 2 && character.inventory.Money > ShopArmor.Cost)
                    {
                        Inventory.GetItemWeapon(character, ShopWeapon);
                        Inventory.LostMoneyArmor(character.inventory, ShopArmor);
                        selectBUY = 4;
                    }
                    else
                    {
                        Console.WriteLine($"У вас недостаточно монет!\n" +
                            $"У вас: {character.inventory.Money} Цена: {ShopArmor.Cost}\n");
                    }
                    if ((selectBUY == 3) && (character.inventory.Money > 10))
                    {
                        character.inventory.Heal += 1;
                    }
                    else
                    {
                        Console.WriteLine($"У вас недостаточно монет!\n" +
                            $"У вас: {character.inventory.Money} Цена: 10\n");
                    }
                }
            }
            if (select == 2)
            {
                int selectSELL = 0;
                Console.WriteLine("Что вы хотите продать?\n\'1\' - основную броню\n\'2\' - основное оружие\n" +
                    "\'3\' - первый слот в инвенторе\n\'4\' - второй слот в инвенторе\n\'5\' - я передумал\n");
                while (selectSELL != 5)
                {
                    selectSELL = Convert.ToInt32(Console.ReadLine());
                    if (selectSELL == 2 && character.inventory.equippedWeapon.WID > 0)
                    {
                        character.inventory.Money += character.inventory.equippedWeapon.Cost;
                        character.inventory.equippedWeapon = new Weapon(0, 0, 0, "Свободная ячейка под оружие", 0);
                        selectSELL = 5;
                    }
                    else
                    {
                        Console.WriteLine("У вас ничего нет\n");
                    }
                    if (selectSELL == 1 && character.inventory.equippedArmor.Type > 0)
                    {
                        character.inventory.Money += character.inventory.equippedArmor.Cost;
                        character.inventory.equippedArmor = new Armor(0, 0, "Свободная ячейка под броню", 0);
                        selectSELL = 5;
                    }
                    else
                    {
                        Console.WriteLine("У вас ничего нет\n");
                    }
                    if (selectSELL == 3 && character.inventory.inventoryArmor.Type > 0)
                    {
                        character.inventory.Money += character.inventory.inventoryArmor.Cost;
                        character.inventory.inventoryArmor = new Armor(0, 0, "Свободная ячейка под броню", 0);
                        selectSELL = 5;
                    }
                    else
                    {
                        Console.WriteLine("У вас ничего нет\n");
                    }
                    if (selectSELL == 4 && character.inventory.inventoryWeapon.Type > 0)
                    {
                        character.inventory.Money += character.inventory.inventoryWeapon.Cost;
                        character.inventory.inventoryWeapon = new Weapon(0, 0, 0, "Свободная ячейка под броню", 0);
                        selectSELL = 5;
                    }
                    else
                    {
                        Console.WriteLine("У вас ничего нет\n");
                    }
                }
            }
        }

    }
}

class Knight : Person
{
    public Knight(float damage, float stamina, float health, float armor, int weapon, string name) : base(damage, stamina, health, armor, weapon, name)
    {

    }
    public override void SpecialSkill()
    {
        _health = _health + 20;
        if (_health > 100)
            _health = 100;
        Console.WriteLine($"Вы востановили здоровье! Количесвто здоровья: {_health}\n");
    }

}

class Archer : Person
{
    public int _stamina;
    public Archer(float damage, float stamina, float health, float armor, int weapon, string name) : base(damage, stamina, health, armor, weapon, name)
    {
    }
    public override void SpecialSkill()
    {
        _damage = _damage * 1.5f;
        _SpellCounter++;
    }
    public override void ReturnSpell()
    {
        _damage /= (float)Math.Pow(1.5f, _SpellCounter); //ДОДЕЛАЙ 
        _SpellCounter = 0;
    }
}

class Thief : Person
{
    public Thief(float damage, float stamina, float health, float armor, int weapon, string name) : base(damage, stamina, health, armor, weapon, name)
    {
    }
    public override void SpecialSkill()
    {
        _armor = _armor / 1.8f;
        _SpellCounter++;
    }
    public override void ReturnSpell()
    {
        _armor *= (float)Math.Pow(1.8f, _SpellCounter); //ДОДЕЛАЙ 
        _SpellCounter = 0;
    }
}






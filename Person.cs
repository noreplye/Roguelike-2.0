using System.Net.Http.Headers;

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
        ScreenInfo screenInfo = new ScreenInfo(1);
        Console.ForegroundColor = ConsoleColor.Green;
        ScreenInfo.AddInfo($"Вашего персонажа зовут: {_name}", screenInfo);
        ScreenInfo.AddInfo(" ", screenInfo);
        ScreenInfo.AddInfo($"Ваши характеристики:", screenInfo);
        ScreenInfo.AddInfo($"Урон = {_damage}", screenInfo);
        ScreenInfo.AddInfo($"Броня = {_armor} ", screenInfo);
        ScreenInfo.AddInfo($"Выносливость = {_stamina}", screenInfo);
        ScreenInfo.AddInfo($"Здоровье = {_health}", screenInfo);
        ScreenInfo.ShowLastInfo(screenInfo);
        Console.ForegroundColor = ConsoleColor.White;

        /*Console.WriteLine($"Вашего персонажа зовут: {_name}\nВаши характеристики:\nУрон = {_damage}\nБроня = " +
            $"{_armor}\nВыносливость = {_stamina}\nЗдоровье = {_health}");*/
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
        if (_health > 100)
        {
            _health = 100;
        }
    }

    public void StaminaChanges(int changes)
    {
        _stamina = _stamina + changes;
    }

    public void TakeDamage(float EnemyDamage)
    {
        _health = _health - (EnemyDamage * (1 - (_armor / 100)));
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
                  (EnemyDamage * 0.5f * (1 - (_armor / 100)));
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
        ScreenInfo BattleInfo = new ScreenInfo(2);
        int stam;
        bool battle = false;
        Person[] enemys =
        {
            new Person(5, 50, 50, 50, 1, "орк"),
            new Person(7, 60, 70, 50, 1, "троль"),
            new Person(3, 30, 30, 50, 1, "слайм"),
            new Person(10, 50, 100, 50, 1, "Ким"),
        };
        ScreenInfo.AddInfo($"Здоровье противника {enemys[rnd].Name}: {enemys[rnd].Health}", BattleInfo);
        ScreenInfo.AddInfo($"На вас напали! Выпить зелье перед ходом(1) или перейти к ходу(2)?", BattleInfo);
        ScreenInfo.ShowLastInfo(BattleInfo);
        ConsoleKeyInfo Selection;
        character.ReturnSpell();

        while (character.Health > 0 && enemys[rnd].Health > 0)
        {
            //Console.WriteLine($"\n\n{character.Armor}\n{character._SpellCounter}\n\n");
            Selection = Console.ReadKey();
            while (Selection.Key != ConsoleKey.D2)
            {
                if ((Selection.Key == ConsoleKey.D1) && (character.inventory.Heal > 0))
                {
                    character.DrinkHeal();
                }

                //Console.WriteLine($"\n\n{character.Armor}\n{character._SpellCounter}\n\n");
                ScreenInfo.AddInfo($"Здоровье противника {enemys[rnd].Name}: {enemys[rnd].Health}", BattleInfo);
                ScreenInfo.AddInfo($"На вас напали! Выпить зелье перед ходом(1) или перейти к ходу(2)?", BattleInfo);
                ScreenInfo.ShowLastInfo(BattleInfo);
                Selection = Console.ReadKey();
            }

            if (Selection.Key == ConsoleKey.D2)
            {
                ScreenInfo.AddInfo($"Какое действие вы выберите?", BattleInfo);
                ScreenInfo.AddInfo($"Атака - 1", BattleInfo);
                ScreenInfo.AddInfo($"Блокировать атаку врага - 2", BattleInfo);
                ScreenInfo.AddInfo($"Специальная способность - 3", BattleInfo);
                ScreenInfo.ShowLastInfo(BattleInfo);
                //Console.WriteLine("\nКакое действие вы выберите?\nАтака - 1\nБлокировать атаку врага - 2\nСпециальная способность - 3");
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
                            ScreenInfo.AddInfo("У вас недостаточно Выносливости! Вы пытаетесь попасть по врагу, но промахиваетесь! Враг вас атаковал!", BattleInfo);
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
                            ScreenInfo.AddInfo("У вас недостаточно Выносливости! Вы пытаетесь попасть по врагу, но промахиваетесь! Враг вас атаковал!", BattleInfo);
                        }
                    }

                    character.TakeDamage(enemys[rnd].Damage);
                    if (character.Health <= 0)
                    {
                        ScreenInfo.AddInfo($"Вы умерли", BattleInfo);
                        ScreenInfo.ShowLastInfo(BattleInfo);
                        battle = true;
                        return;
                    }

                    if (enemys[rnd].Health <= 0)
                    {
                        character.ReturnSpell();
                        ScreenInfo.AddInfo($"Вы победили врага", BattleInfo);
                        ScreenInfo.ShowLastInfo(BattleInfo);
                        battle = true;
                        return;
                    }

                    ScreenInfo.AddInfo($"Здоровье противника {enemys[rnd].Name}: {enemys[rnd].Health}", BattleInfo);
                    ScreenInfo.AddInfo($"Какое действие вы выберите?", BattleInfo);
                    ScreenInfo.AddInfo($"Атака - 1", BattleInfo);
                    ScreenInfo.AddInfo($"Блокировать атаку врага - 2", BattleInfo);
                    ScreenInfo.AddInfo($"Специальная способность - 3", BattleInfo);
                    ScreenInfo.ShowLastInfo(BattleInfo);
                    character.ShowStats();
                    Selection = Console.ReadKey();
                }
            }

            character.ShowStats();
            ScreenInfo.ShowLastInfo(BattleInfo);
            //Console.WriteLine($"\nВаше здоровье: {character.Health}\nВаша выносливость: {character.Stamina}\nЗдоровье противника {enemys[rnd].Name}: {enemys[rnd].Health}\n");
        }
    }

    public static void OpenChest(Person character)
    {
        int toget = new Random().Next(0, 5); // 0 - монетка, 1 - фласка, 2 - броня, 3 - оружие, 4 - ничего
        ScreenInfo ChestInfo = new ScreenInfo(3);
        if (toget == 3)
        {
            int index = 0;
            Weapon[] weapon =
            {
                new Weapon(1, 0, 2, "дубовая палка", 10),
                new Weapon(1, 0, 2, "Ржавая труба", 15),
                new Weapon(1, 0, 2, "Кочерга", 20),
                new Weapon(1, 0, 8, "Арматура", 20),
                new Weapon(1, 0, 8, "Меч", 20),
                new Weapon(1, 0, 1000, "Меч короля Артура", 2890),
                new Weapon(2, 1, 2, "Рогатка-1", 10),
                new Weapon(2, 1, 2, "Рогатка-2", 10),
                new Weapon(2, 1, 2, "Рогатка-3", 10),
                new Weapon(2, 1, 8, "Рогатка-4", 10),
                new Weapon(2, 1, 8, "Лук 5 уровоня", 15),
                new Weapon(2, 1, 1240, "Лук 6 уровоня", 20),
                new Weapon(3, 2, 2, "Зубочистка 1 уровня", 10),
                new Weapon(3, 2, 2, "Зубочистка 2 уровня", 10),
                new Weapon(3, 2, 2, "Зубочистка 3 уровня", 10),
                new Weapon(3, 2, 8, "Зубочистка 4 уровня", 10),
                new Weapon(3, 2, 8, "Зубочистка 5 уровня", 15),
                new Weapon(3, 2, 190201, "Зубочистка 6 уровня", 20)
            };
            if (character._WeaponId == 1)
            {
                index = new Random().Next(0, 6);
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
            ScreenInfo.AddInfo($"Вам выпало {WeaponToGet.ItemName} - Урон:{WeaponToGet.ItemStats}, Стоимость:{WeaponToGet.ItemCost}", ChestInfo);
            ScreenInfo.ShowLastInfo(ChestInfo);
            Inventory.GetItemWeapon(character, WeaponToGet);
            Console.Clear();
        }

        if (toget == 2)
        {
            int index = 0;
            Armor[] armor =
            {
                new Armor(3, 5, "Картон - 1", 10),
                new Armor(3, 6, "Картон - 2", 11),
                new Armor(3, 7, "Картон - 3", 12),
                new Armor(4, 8, "Резиновая подстилка - 1", 13),
                new Armor(4, 9, "Резиновая подстилка - 2", 14),
                new Armor(4, 10, "Резиновая подстилка - 3", 15),
                new Armor(5, 11, "Кульчуга - 1", 16),
                new Armor(5, 12, "Кульчуга - 2", 17),
                new Armor(5, 13, "Кульчуга - 3", 18),
            };
            index = new Random().Next(0, armor.Length);
            Armor ArmorToGet = armor[index];
            ScreenInfo.AddInfo($"Вам выпало {ArmorToGet.ItemName} - Броня:{ArmorToGet.ItemStats}, Стоимость:{ArmorToGet.ItemCost}", ChestInfo);
            ScreenInfo.ShowLastInfo(ChestInfo);
            Inventory.GetItemArmor(character, ArmorToGet);
            Console.Clear();
        }

        if (toget == 0)
        {
            ScreenInfo.AddInfo("Вам выпала монетка", ChestInfo);
            ScreenInfo.ShowLastInfo(ChestInfo);
            Inventory.GetMoney(character.inventory);
            Console.ReadKey();
        }

        if (toget == 1)
        {
            ScreenInfo.AddInfo("Вам выпало зелье здоровья", ChestInfo);
            ScreenInfo.ShowLastInfo(ChestInfo);
            Inventory.GetHeal(character.inventory);
            Console.ReadKey();
        }
        if (toget == 4)
        {
            ScreenInfo.AddInfo("Вам ничего не выпало", ChestInfo);
            ScreenInfo.ShowLastInfo(ChestInfo);
            Console.ReadKey();
        }
    }

    public static void Shop(Person character)
    {
        Armor[] armor =
        {
            new Armor(3, 5, "Картон - 1", 10),
            new Armor(3, 6, "Картон - 2", 11),
            new Armor(3, 7, "Картон - 3", 12),
            new Armor(4, 8, "Резиновая подстилка - 1", 13),
            new Armor(4, 9, "Резиновая подстилка - 2", 14),
            new Armor(4, 10, "Резиновая подстилка - 3", 15),
            new Armor(5, 11, "Кульчуга - 1", 16),
            new Armor(5, 12, "Кульчуга - 2", 17),
            new Armor(5, 13, "Кульчуга - 3", 18),
        };
        Weapon[] weapon =
        {
            new Weapon(1, 0, 2, "Дубовая палка", 10),
            new Weapon(1, 0, 2, "Ржавая труба", 15),
            new Weapon(1, 0, 2, "Кочерга", 20),
            new Weapon(1, 0, 8, "Арматура", 20),
            new Weapon(1, 0, 8, "Меч", 20),
            new Weapon(1, 0, 1000, "Меч короля Артура", 2890),
            new Weapon(2, 1, 2, "Рогатка-1", 10),
            new Weapon(2, 1, 2, "Рогатка-2", 10),
            new Weapon(2, 1, 2, "Рогатка-3", 10),
            new Weapon(2, 1, 8, "Рогатка-4", 10),
            new Weapon(2, 1, 8, "Лук 5 уровоня", 15),
            new Weapon(2, 1, 1240, "Лук 6 уровоня", 20),
            new Weapon(3, 2, 2, "Зубочистка 1 уровня", 10),
            new Weapon(3, 2, 2, "Зубочистка 2 уровня", 10),
            new Weapon(3, 2, 2, "Зубочистка 3 уровня", 10),
            new Weapon(3, 2, 8, "Зубочистка 4 уровня", 10),
            new Weapon(3, 2, 8, "Зубочистка 5 уровня", 15),
            new Weapon(3, 2, 190201, "Зубочистка 6 уровня", 20)
        };
        Random rand = new Random();
        int index = new Random().Next(0, armor.Length);
        int index1 = new Random().Next(0, weapon.Length);
        ConsoleKeyInfo _pushedKey;
        ScreenInfo ShopInfo = new ScreenInfo(5);
        while (1==1)
        {
            ScreenInfo.AddInfo($"Приветствую тебя, добрый путник {character.Name}, в самом лучшем и единственном магазине во всем подземелье!", ShopInfo);
            ScreenInfo.AddInfo("Лучшем, потому что нет аналогов! Единственном, потому что только я не боюсь этих мест! Чего ты желаешь?", ShopInfo);
            ScreenInfo.AddInfo("\'1\' - купить предмет", ShopInfo);
            ScreenInfo.AddInfo("\'2\' - продать предмет", ShopInfo);
            ScreenInfo.AddInfo("\'3\' - покинуть магазин (Если вы покините магазин, то не сможете вернуться в него на этом уровне)", ShopInfo);
            ScreenInfo.ShowLastInfo(ShopInfo);
            _pushedKey = Console.ReadKey();
            if (_pushedKey.Key == ConsoleKey.D1)
            {
                Armor ShopArmor = armor[index];
                Weapon ShopWeapon = weapon[index];

                while (_pushedKey.Key != ConsoleKey.D4)
                {
                    ScreenInfo.AddInfo($"Ого! {character.Name}, вам очень повезло! Сегодня в ассортименте:", ShopInfo);
                    ScreenInfo.AddInfo($"Броня: {ShopArmor.ItemName} - защита:{ShopArmor.ItemStats}, цена:{ShopArmor.ItemCost}", ShopInfo);
                    ScreenInfo.AddInfo($"Оружие: {ShopWeapon.ItemName} - защита:{ShopWeapon.ItemStats}, цена:{ShopWeapon.ItemCost}", ShopInfo);
                    ScreenInfo.AddInfo("Желаете что-нибудь приобрести?", ShopInfo);
                    ScreenInfo.AddInfo("\'1\' - броню", ShopInfo);
                    ScreenInfo.AddInfo("\'2\' - оружие", ShopInfo);
                    ScreenInfo.AddInfo("\'3\' - зелье", ShopInfo);
                    ScreenInfo.AddInfo("\'4\' - воздержусь", ShopInfo);
                    ScreenInfo.ShowLastInfo(ShopInfo);
                    _pushedKey = Console.ReadKey();
                    if (_pushedKey.Key == ConsoleKey.D1)
                    {
                        if (character.inventory.Money > ShopWeapon.ItemCost)
                        {
                            Inventory.GetItemArmor(character, ShopArmor);
                            Inventory.LostMoneyWeapon(character.inventory, ShopWeapon);
                            break;
                        }
                        else
                        {
                            ScreenInfo.AddInfo("У вас недостаточно монет!", ShopInfo);
                            ScreenInfo.AddInfo($"У вас: {character.inventory.Money} Цена: {ShopWeapon.ItemCost}", ShopInfo);
                            ScreenInfo.AddInfo($"Для продолжения нажмите enter...", ShopInfo);
                            ScreenInfo.ShowLastInfo(ShopInfo);
                            _pushedKey = Console.ReadKey();
                            while (_pushedKey.Key != ConsoleKey.Enter) { _pushedKey = Console.ReadKey(); }
                        }
                    }


                    if (_pushedKey.Key == ConsoleKey.D2)
                    {
                        if (character.inventory.Money > ShopArmor.ItemCost)
                        {
                            Inventory.GetItemWeapon(character, ShopWeapon);
                            Inventory.LostMoneyArmor(character.inventory, ShopArmor);
                            break;
                        }
                        else
                        {
                            ScreenInfo.AddInfo("У вас недостаточно монет!", ShopInfo);
                            ScreenInfo.AddInfo($"У вас: {character.inventory.Money} Цена: {ShopWeapon.ItemCost}", ShopInfo);
                            ScreenInfo.AddInfo($"Для продолжения нажмите enter...", ShopInfo);
                            ScreenInfo.ShowLastInfo(ShopInfo);
                            _pushedKey = Console.ReadKey();
                            while (_pushedKey.Key != ConsoleKey.Enter) { _pushedKey = Console.ReadKey(); }

                        }
                    }


                    if (_pushedKey.Key == ConsoleKey.D3)
                    {
                        if (character.inventory.Money > 10)
                        {
                            character.inventory.Heal += 1;
                        }
                        else
                        {
                            ScreenInfo.AddInfo($"У вас недостаточно монет!", ShopInfo);
                            ScreenInfo.AddInfo($"У вас: {character.inventory.Money} Цена: 10", ShopInfo);
                            ScreenInfo.AddInfo($"Для продолжения нажмите enter...", ShopInfo);
                            ScreenInfo.ShowLastInfo(ShopInfo);
                            _pushedKey = Console.ReadKey();
                            while (_pushedKey.Key != ConsoleKey.Enter) { _pushedKey = Console.ReadKey(); }
                        }
                    }
                }
            }

            if (_pushedKey.Key == ConsoleKey.D2)
            {
                
                while (_pushedKey.Key != ConsoleKey.D5)
                {
                    ScreenInfo.AddInfo("Что вы хотите продать?", ShopInfo);
                    ScreenInfo.AddInfo("\'1\' - основную броню", ShopInfo);
                    ScreenInfo.AddInfo("\'2\' - основное оружие", ShopInfo);
                    ScreenInfo.AddInfo("\'3\' - первый слот в инвентаре", ShopInfo);
                    ScreenInfo.AddInfo("\'4\' - второй слот в инвентаре", ShopInfo);
                    ScreenInfo.AddInfo("\'5\' - я передумал", ShopInfo);
                    ScreenInfo.ShowLastInfo(ShopInfo);
                    _pushedKey = Console.ReadKey();
                    if (_pushedKey.Key == ConsoleKey.D2)
                    {
                        if (character.inventory.equippedWeapon.Id > 0)
                        {
                            character.inventory.Money += character.inventory.equippedWeapon.ItemCost;
                            character.inventory.equippedWeapon = new Weapon(0, 0, 0, "Свободная ячейка под оружие", 0);
                            break;
                        }
                        else
                        {
                            ScreenInfo.AddInfo("У вас ничего нет\n", ShopInfo);
                            ScreenInfo.AddInfo($"Для продолжения нажмите enter...", ShopInfo);
                            ScreenInfo.ShowLastInfo(ShopInfo);
                            _pushedKey = Console.ReadKey();
                            while (_pushedKey.Key != ConsoleKey.Enter) { _pushedKey = Console.ReadKey(); }
                        }
                    }


                    if (_pushedKey.Key == ConsoleKey.D1)
                    {
                        if (character.inventory.equippedArmor.Type > 0)
                        {
                            character.inventory.Money += character.inventory.equippedArmor.ItemCost;
                            character.inventory.equippedArmor = new Armor(0, 0, "Свободная ячейка под броню", 0);
                            break;
                        }
                        else
                        {
                            ScreenInfo.AddInfo("У вас ничего нет\n", ShopInfo);
                            ScreenInfo.AddInfo($"Для продолжения нажмите enter...", ShopInfo);
                            ScreenInfo.ShowLastInfo(ShopInfo);
                            _pushedKey = Console.ReadKey();
                            while (_pushedKey.Key != ConsoleKey.Enter) { _pushedKey = Console.ReadKey(); }
                        }
                    }


                    if (_pushedKey.Key == ConsoleKey.D3)
                    {
                        if (character.inventory.inventoryArmor.Type > 0)
                        {
                            character.inventory.Money += character.inventory.inventoryArmor.ItemCost;
                            character.inventory.inventoryArmor = new Armor(0, 0, "Свободная ячейка под броню", 0);
                            break;
                        }
                        else
                        {
                            ScreenInfo.AddInfo("У вас ничего нет\n", ShopInfo);
                            ScreenInfo.AddInfo($"Для продолжения нажмите enter...", ShopInfo);
                            ScreenInfo.ShowLastInfo(ShopInfo);
                            _pushedKey = Console.ReadKey();
                            while (_pushedKey.Key != ConsoleKey.Enter) { _pushedKey = Console.ReadKey(); }
                        }
                    }


                    if (_pushedKey.Key == ConsoleKey.D4)
                    {
                        if (character.inventory.inventoryWeapon.Type > 0)
                        {
                            character.inventory.Money += character.inventory.inventoryWeapon.ItemCost;
                            character.inventory.inventoryWeapon = new Weapon(0, 0, 0, "Свободная ячейка под броню", 0);
                            break;
                        }
                        else
                        {
                            ScreenInfo.AddInfo("У вас ничего нет\n", ShopInfo);
                            ScreenInfo.AddInfo($"Для продолжения нажмите enter...", ShopInfo);
                            ScreenInfo.ShowLastInfo(ShopInfo);
                            _pushedKey = Console.ReadKey();
                            while (_pushedKey.Key != ConsoleKey.Enter) { _pushedKey = Console.ReadKey(); }
                        }
                    }
                }
            }
            if (_pushedKey.Key == ConsoleKey.D3)
            {
                ScreenInfo.ShowLastInfo(ShopInfo);
                return;
            }
        }
    }
}




class Knight : Person
{
    public Knight(float damage, float stamina, float health, float armor, int weapon, string name) : base(damage,
        stamina, health, armor, weapon, name)
    {
    }

    public override void SpecialSkill()
    {
        ScreenInfo SpecialSkillInfo = new ScreenInfo(4);
        _health = _health + 20;
        if (_health > 100)
            _health = 100;
        ScreenInfo.AddInfo($"Вы востановили здоровье! Количесвто здоровья: {_health}\n", SpecialSkillInfo);
        ScreenInfo.ShowLastInfo(SpecialSkillInfo);
    }
}

class Archer : Person
{
    public int _stamina;

    public Archer(float damage, float stamina, float health, float armor, int weapon, string name) : base(damage,
        stamina, health, armor, weapon, name)
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
    public Thief(float damage, float stamina, float health, float armor, int weapon, string name) : base(damage,
        stamina, health, armor, weapon, name)
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
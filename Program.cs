using System;



class Program
{

    static void Battle(Person character)

    {
        int stam;
        bool battle = false;
        Random random = new Random();
        int rnd = random.Next(0, 3);
        Person[] enemys =
        {
            new Person(5, 50, 50, 100, 1, "орк"),
            new Person(7, 60, 70, 100, 1, "троль"),
            new Person(3, 30, 30, 100, 1, "слайм"),
        };

        Console.WriteLine($"\nВаше здоровье: {character.Health}\nЗдоровье противника {enemys[rnd].Name}: {enemys[rnd].Health}\n");
        int Selection;
        character.ReturnSpell();

        while (character.Health > 0 && enemys[rnd].Health > 0)
        {
            Console.WriteLine($"\n\n{character.Armor}\n{character._SpellCounter}\n\n");
            Console.WriteLine("На вас напали! Выпить зелье перед ходом(1) или перейти к ходу(2)?");
            Selection = Convert.ToInt32(Console.ReadLine());
            if (Selection == 1)
            {

                if (character.Heal > 0)
                {
                    character.DrinkHeal();
                }
            }
            else if (Selection == 2)
            {
                battle = false;
                Console.WriteLine("Какое действие вы выберите?\nАтака - 1\nБлокировать атаку врага - 2\nСпециальная способность - 3");
                Selection = Convert.ToInt32(Console.ReadLine());
                while (battle == false)
                {

                    if (Selection == 1)
                    {
                        if (character.Stamina > 19)
                        {
                            stam = -20;
                            character.StaminaChanges(stam);
                            enemys[rnd].TakeDamage(character.Damage);
                            battle = true;
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно Выносливости! Вы пытаетесь попасть по врагу, но промахиваетесь! Враг вас атаковал!");
                            battle = true;
                        }
                    }
                    else if (Selection == 2)
                    {
                        stam = 10;
                        character.BlockDamage(enemys[rnd].Damage);
                        character.StaminaChanges(stam);
                        battle = true;
                    }
                    else if (Selection == 3)
                    {
                        if (character.Stamina > 49)
                        {
                            stam = -50;
                            character.StaminaChanges(stam);
                            character.SpecialSkill();
                            battle = true;
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно Выносливости! Вы пытаетесь скастовать способность, но у вас ничего не вышло! Враг вас атаковал!");
                            battle = true;
                        }
                    }
                }
                character.TakeDamage(enemys[rnd].Damage);
            }
            Console.WriteLine($"Ваше здоровье: {character.Health}\nВаша выносливость: {character.Stamina}\nЗдоровье противника {enemys[rnd].Name}: {enemys[rnd].Health}\n");
            if (character.Health <= 0)
            {
                Console.WriteLine("Вы умерли");
            }
            else if (enemys[rnd].Health <= 0)
            {
                character.ReturnSpell();
                Console.WriteLine("Вы победили");
            }
        }
    }
    private static Factory GetMyPerson(int ClassSelection) =>
        ClassSelection switch
        {
            1 => new GetKnight(),
            2 => new GerArcher(),
            3 => new GetThief(),
            _ => null
        };

    public static void Main(string[] args)
    {
        Console.Write("Введите имя вашего персонажа: ");
        string name = Console.ReadLine();

        Console.WriteLine("Выберите класс вашего персонажа: \n 1. Рыцарь \n 2. Лучник \n 3. Вор\n");
        int ClassSelection = Convert.ToInt32(Console.ReadLine());

        Factory factory = GetMyPerson(ClassSelection);
        Person character = factory.GetMyPerson();
        character.TakeName(name);
        character.ShowStats();

        // Person YourPerson = persons[Class_Selection];
        //YourPerson.ShowStats();

        // Outfit weapon = new Outfit(0, 2, 10, "Меч", 10);
        // Console.WriteLine($"Хотите надеть {weapon.ItemName}?");
        // string answer;
        // answer = Console.ReadLine();
        // if (answer == "да")
        // {
        //    Outfit ActiveWeapon = weapon;
        //   YourPerson.PutOnWeapon(ActiveWeapon.ItemStats);
        // }
        int level = 0;
        while (character.Health > 0 && level < 10)
        {
            level++;
            Console.WriteLine($"Уровень подземелья: {level}");
            Battle(character);
            if (character.Health <= 0)
            {
                Console.WriteLine("Увы, но вы проиграли :(");
            }
            if (level == 10)
            {
                Console.WriteLine("Поздравляю! Вы прошли последний уровень!");
            }
        }


        Console.ReadKey();

    }
}

using System.Reflection.PortableExecutable;
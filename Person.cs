using System;
abstract class Factory
{
    public abstract Person GetMyPerson();
}

class GetKnight : Factory
{
    public override Person GetMyPerson()
    {
        Knight knight = new(200, 1000, 100, 100, 100, "");
        return knight;
    }


}

class GerArcher : Factory
{
    public override Person GetMyPerson()
    {
        Archer archer = new(111, 111, 111, 111, 111, "");
        return archer;
    }


}

class GetThief : Factory
{
    public override Person GetMyPerson()
    {
        Thief thief = new(122, 122, 122, 122, 122, "");
        return thief;
    }


}
class Person
{
    public float _damage;
    private float _stamina;
    public float _health;
    private string _name;
    public float _armor;
    private int _WeaponId;
    private int _Money; // Дописать взаимодействие с деньгами
    public int costil = 0;

    public Person(float damage, float stamina, float health, float armor, int weapon, string name)
    {
        _damage = damage;
        _stamina = stamina;
        _health = health;
        _armor = armor;
        _name = name;
        _WeaponId = weapon;
    }

    public void ShowStats()
    {
        Console.WriteLine($"Вашего персонажа зовут: {_name}\nВаши характеристики:\nУрон = {_damage}\nБроня = " +
            $"{_armor}\nВыносливость = {_stamina}\nЗдоровье = {_health}");
    }
    public void UseCostil(int costil)
    {
        if (costil < 0)
        {
            _damage = _damage / 1.5f / (-1 * costil);
        }
        if (costil > 0)
        {
            _armor = _armor * 1.8f * costil;
        }
    }

    public float Health => _health;
    public string Name => _name;
    public float Damage => _damage;
    public float Armor => _armor;

    public void TakeName(string name)
    {
        _name = name;
    }

    public void TakeDamage(float EnemyDamage)
    {
        _health = _health - EnemyDamage * (_armor / 100);
    }

    public void PutOnWeapon(int ItemStats)
    {
        _damage = _damage + ItemStats;
        Console.WriteLine($"Ваш урон: {_damage}");
    }

    public void TakeOfWeapon(int ItemStats)
    {
        _damage = _damage - ItemStats;
        Console.WriteLine($"Ваш урон: {_damage}");
    }
    public void PutOnArmor(int ItemStats)
    {
        _armor = _armor - ItemStats;
        Console.WriteLine($"Ваш урон: {_damage}");
    }
    public void TakeOfArmor(int ItemStats)
    {
        _armor = _armor + ItemStats;
        Console.WriteLine($"Ваша броня: {_armor}");
    }

    public void BlockDamage(float EnemyDamage)
    {
        _health = _health - (EnemyDamage * 0.5f -
        EnemyDamage * (_armor / 100));

    }
    virtual public void SpecialSkill()
    {

    }
}

class Knight : Person
{
    public Knight(float damage, float stamina, float health, float armor, int weapon, string name) : base(damage, stamina, health, armor, weapon, name)
    {

    }
    public override void SpecialSkill()
    {
        _health = _health + 5;
        if (_health > 100)
            _health = 100;
        Console.WriteLine($"Вы востановили здоровье! Количесвто здоровья: {_health}\n");
    }

}

class Archer : Person
{
    public int costil;
    public int Costil => costil;
    public Archer(float damage, float stamina, float health, float armor, int weapon, string name) : base(damage, stamina, health, armor, weapon, name)
    {
    }
    public override void SpecialSkill()
    {
        _damage = _damage * 1.5f;
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
    }
}

class Item //Класс предмета
{

    public int ItemStats; //статы предмета, если оружие, то + урон, если броня,то + броня, если зелье, то ну блять понятно 
    public string ItemName; //название предмета
    public int ItemCost; // цена на предмет
    public int GiveStats => ItemStats; // должно возвращать значение статистики, чтобы +/- к начальному

}
class Weapon : Item
{
    public int Id;  // Id сделан для того, чтобы в зависисмости от выбранного класс можно было бы надеть на перса или нет (принимает WeaponId)
    public int Type; // тип снаряжения 0-2 оружие (Меч, Лук, Нож), 3-5 броня (Тяжелая, Средняя, Легкая)
    public Weapon(int OutfitId, int OutfitType, int OutfitStats, string OutfitName, int OutfitCost)
    {
        Id = OutfitId;
        Type = OutfitType;
        ItemStats = OutfitStats;
        ItemName = OutfitName;
        ItemCost = OutfitCost;
    }


}

class Armor : Item
{
    public int Id;  // Id сделан для того, чтобы в зависисмости от выбранного класс можно было бы надеть на перса или нет (принимает WeaponId)
    public int Type; // тип снаряжения 0-2 оружие (Меч, Лук, Нож), 3-5 броня (Тяжелая, Средняя, Легкая)
    public Armor(int OutfitId, int OutfitType, int OutfitStats, string OutfitName, int OutfitCost)
    {
        Id = OutfitId;
        Type = OutfitType;
        ItemStats = OutfitStats;
        ItemName = OutfitName;
        ItemCost = OutfitCost;
    }

}

class Program
{

    static void Battle(Person character)

    {
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
        while (character.Health > 0 && enemys[rnd].Health > 0)
        {
            Console.WriteLine("Какое действие вы выберите?\nАтака - 1\nБлокировать атаку врага - 2\nСпециальная способность - 3");
            Selection = Convert.ToInt32(Console.ReadLine());
            switch (Selection)
            {
                case 1:
                    enemys[rnd].TakeDamage(character.Damage);
                    break;
                case 2:
                    character.BlockDamage(enemys[rnd].Damage);
                    break;
                case 3:
                    character.SpecialSkill();
                    break;
            };
            character.TakeDamage(enemys[rnd].Damage);
            Console.WriteLine($"Ваше здоровье: {character.Health}\nЗдоровье противника {enemys[rnd].Name}: {enemys[rnd].Health}\n");
            if (character.Health <= 0)
            {
                Console.WriteLine("Вы умерли");
            }
            else if (enemys[rnd].Health <= 0)
            {
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

        while (character.Health >= 0 && level < 10)
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

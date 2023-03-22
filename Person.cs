abstract class Factory
{
    public abstract Person GetMyPerson();
}

class GetKnight : Factory
{
    public override Person GetMyPerson()
    {
        Knight knight = new(200, 80, 100, 100, 100, "");
        return knight;
    }


}

class GerArcher : Factory
{
    public override Person GetMyPerson()
    {
        Archer archer = new(20, 111, 111, 111, 111, "");
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
public class Person
{
    public float _damage;
    private float _stamina;
    public float _health;
    private string _name;
    public float _armor;
    private int _WeaponId;
    private int _Money; // Дописать взаимодействие с деньгами
    public int _HealCOLVO = 1;
    public int _SpellCounter = 0;
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

    public float Health => _health;

    public float Stamina => _stamina;
    public string Name => _name;
    public float Damage => _damage;
    public float Armor => _armor;
    public int Heal => _HealCOLVO;
    public void TakeName(string name)
    {
        _name = name;
    }
    public void DrinkHeal()
    {
        _HealCOLVO -= 1;
        _health = _health + 30;
        if (_health > 100) { _health = 100; }
    }
    public void StaminaChanges(int changes)
    {
        _stamina = _stamina + changes;
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
        _stamina += 10;
    }
    virtual public void SpecialSkill()
    {
        _SpellCounter++;
    }
    virtual public void ReturnSpell()
    {

    }
    public static void Battle(Person character)
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
                    if ((Selection.Key != ConsoleKey.D2)&&( character.Heal > 0))
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
                Console.WriteLine("Какое действие вы выберите?\nАтака - 1\nБлокировать атаку врага - 2\nСпециальная способность - 3");
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
                            Console.WriteLine("У вас недостаточно Выносливости! Вы пытаетесь попасть по врагу, но промахиваетесь! Враг вас атаковал!");
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
                            Console.WriteLine("У вас недостаточно Выносливости! Вы пытаетесь скастовать способность, но у вас ничего не вышло! Враг вас атаковал!");
                        }
                    }
                    Console.Write($"\nВаше здоровье: {character.Health}\nЗдоровье противника {enemys[rnd].Name}: {enemys[rnd].Health}\n");
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
                        Console.WriteLine("Вы победили");
                        battle = true;
                        break;
                    }
                    Console.WriteLine("Какое действие вы выберите?\nАтака - 1\nБлокировать атаку врага - 2\nСпециальная способность - 3");
                    Selection = Console.ReadKey();
                }
            }
            Console.WriteLine($"Ваше здоровье: {character.Health}\nВаша выносливость: {character.Stamina}\nЗдоровье противника {enemys[rnd].Name}: {enemys[rnd].Health}\n");
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






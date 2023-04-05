using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

internal class Program

{
    public class Inventorya
    {
        public Armor equippedArmor = new Armor(0, 0, "Свободная ячейка под броню", 0);
        public Weapon equippedWeapon = new Weapon(0, 0, 0, "Свободная ячейка под оружие", 0);
        public Armor inventoryArmor = new Armor(0, 0, "Свободная ячейка под броню", 0);
        public Weapon inventoryWeapon = new Weapon(0, 0, 0, "Свободная ячейка под оружие", 0);
        public int Heal = 1;
        public int Money = 0;
    }
    static void Main(string[] args)
    {
        ScreenMenu.StartGreeting();
        ScreenMenu.StartNaming();
        ScreenMenu.Menu(5,18,171,4);
        Game.GameProcess();
        
    }
}
public abstract class Item //Класс предмета
{

    public int ItemStats; //статы предмета, если оружие, то + урон, если броня,то + броня, если зелье, то ну блять понятно 
    public string ItemName; //название предмета
    public int ItemCost; // цена на предмет
    public int GiveStats => ItemStats; // должно возвращать значение статистики, чтобы +/- к начальному

}
public class Weapon : Item
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

    public int WID => Id;
}
 
public class Armor : Item
{
    //public int Id;  // Id сделан для того, чтобы в зависисмости от выбранного класс можно было бы надеть на перса или нет (принимает WeaponId)
    public int Type; // тип снаряжения 0-2 оружие (Меч, Лук, Нож), 3-5 броня (Тяжелая, Средняя, Легкая)
    public Armor(/*int OutfitId,*/int OutfitType, int OutfitStats, string OutfitName, int OutfitCost)
    {
        //Id = OutfitId;
        Type = OutfitType;
        ItemStats = OutfitStats;
        ItemName = OutfitName;
        ItemCost = OutfitCost;
    }

}
using System.IO;
using System.Text.Json;

public class GameSettings
{
    public float _KnightDamage; public float _KnightStamina; public float _KnightHealth; public float _KnightArmor; public int _KnightWeapon;
    public float _ArcherDamage; public float _ArcherStamina; public float _ArcherHealth; public float _ArcherArmor; public int _ArcherWeapon;
    public float _ThiefDamage; public float _ThiefStamina; public float _ThiefHealth; public float _ThiefArmor; public int _ThiefWeapon;
    public float _OrcDamage; public float _OrcStamina; public float _OrcHealth; public float _OrcArmor; public int _OrcWeapon;
    public float _TrollDamage; public float _TrollStamina; public float _TrollHealth; public float _TrollArmor; public int _TrollWeapon;
    public float _SlimeDamage; public float _SlimeStamina; public float _SlimeHealth; public float _SlimeArmor; public int _SlimeWeapon;
    public float _KimDamage; public float _KimStamina; public float _KimHealth; public float _KimArmor; public int _KimWeapon;
    public int _isOp; public string _OpWeaponName; public string _OpArmorName; public int _OpArmorStats; public int _OpWeaponStats;
    public int _OpMoney; public int _OpHeal;public int _BlockDamageRecover;
    public float KnightDamage
    {
        get { return _KnightDamage; }
        set { _KnightDamage = value; }
    }
    public float KnightStamina
    {
        get { return _KnightStamina; }
        set { _KnightStamina = value; }
    }
    public float KnightHealth
    {
        get { return _KnightHealth; }
        set { _KnightHealth = value; }
    }
    public float KnightArmor
    {
        get { return _KnightArmor; }
        set { _KnightArmor = value; }
    }
    public int KnightWeapon
    {
        get { return _KnightWeapon; }
        set { _KnightWeapon = value; }
    }
    public float ArcherDamage
    {
        get { return _ArcherDamage; }
        set { _ArcherDamage = value; }
    }
    public float ArcherStamina
    {
        get { return _ArcherStamina; }
        set { _ArcherStamina = value; }
    }
    public float ArcherHealth
    {
        get { return _ArcherHealth; }
        set { _ArcherHealth = value; }
    }
    public float ArcherArmor
    {
        get { return _ArcherArmor; }
        set { _ArcherArmor = value; }
    }
    public int ArcherWeapon
    {
        get { return _ArcherWeapon; }
        set { _ArcherWeapon = value; }
    }
    public float ThiefDamage
    {
        get { return _ThiefDamage; }
        set { _ThiefDamage = value; }
    }
    public float ThiefStamina
    {
        get { return _ThiefStamina; }
        set { _ThiefStamina = value; }
    }
    public float ThiefHealth
    {
        get { return _ThiefHealth; }
        set { _ThiefHealth = value; }
    }
    public float ThiefArmor
    {
        get { return _ThiefArmor; }
        set { _ThiefArmor = value; }
    }
    public int ThiefWeapon
    {
        get { return _ThiefWeapon; }
        set { _ThiefWeapon = value; }
    }
    public float OrcDamage
    {
        get { return _OrcDamage; }
        set { _OrcDamage = value; }
    }
    public float OrcStamina
    {
        get { return _OrcStamina; }
        set { _OrcStamina = value; }
    }
    public float OrcHealth
    {
        get { return _OrcHealth; }
        set { _OrcHealth = value; }
    }
    public float OrcArmor
    {
        get { return _OrcArmor; }
        set { _OrcArmor = value; }
    }
    public int OrcWeapon
    {
        get { return _OrcWeapon; }
        set { _OrcWeapon = value; }
    }
    public float TrollDamage
    {
        get { return _TrollDamage; }
        set { _TrollDamage = value; }
    }
    public float TrollStamina
    {
        get { return _TrollStamina; }
        set { _TrollStamina = value; }
    }
    public float TrollHealth
    {
        get { return _TrollHealth; }
        set { _TrollHealth = value; }
    }
    public float TrollArmor
    {
        get { return _TrollArmor; }
        set { _TrollArmor = value; }
    }
    public int TrollWeapon
    {
        get { return _TrollWeapon; }
        set { _TrollWeapon = value; }
    }
    public float SlimeDamage
    {
        get { return _SlimeDamage; }
        set { _SlimeDamage = value; }
    }
    public float SlimeStamina
    {
        get { return _SlimeStamina; }
        set { _SlimeStamina = value; }
    }
    public float SlimeHealth
    {
        get { return _SlimeHealth; }
        set { _SlimeHealth = value; }
    }
    public float SlimeArmor
    {
        get { return _SlimeArmor; }
        set { _SlimeArmor = value; }
    }
    public int SlimeWeapon
    {
        get { return _SlimeWeapon; }
        set { _SlimeWeapon = value; }
    }

    public float KimDamage
    {
        get { return _KimDamage; }
        set { _KimDamage = value; }
    }
    public float KimStamina
    {
        get { return _KimStamina; }
        set { _KimStamina = value; }
    }
    public float KimHealth
    {
        get { return _KimHealth; }
        set { _KimHealth = value; }
    }
    public float KimArmor
    {
        get { return _KimArmor; }
        set { _KimArmor = value; }
    }
    public int KimWeapon
    {
        get { return _KimWeapon; }
        set { _KimWeapon = value; }
    }
    public int isOp
    {
        get { return _isOp; }
        set { _isOp = value; }
    }
    public string OpWeaponName
    {
        get { return _OpWeaponName; }
        set { _OpWeaponName = value; }
    }
    public string OpArmorName
    {
        get { return _OpArmorName; }
        set { _OpArmorName = value; }
    }
    public int OpWeaponStats
    {
        get { return _OpWeaponStats; }
        set { _OpWeaponStats = value; }
    }
    public int OpArmorStats
    {
        get { return _OpArmorStats; }
        set { _OpArmorStats = value; }
    }
    public int OpMoney
    {
        get { return _OpMoney; }
        set { _OpMoney = value; }
    }
    public int OpHeal
    {
        get { return _OpHeal; }
        set { _OpHeal = value; }
    }

    public int BlockDamageRecover
    {
        get { return _BlockDamageRecover; }
        set { _BlockDamageRecover = value; }
    }
    public static GameSettings Game_Settings()
    {
        Stream SettingsStream = new FileStream(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetFullPath("Settings.json"))))) + "\\Settings.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        string fileText;
        fileText = new StreamReader(SettingsStream).ReadToEnd();
        RootSettings obj = JsonSerializer.Deserialize<RootSettings>(fileText);
        return obj;
    }
}





public class RootSettings:GameSettings
{
    public float KnightDamage
    {
        get { return _KnightDamage; }
        set { _KnightDamage = value; }
    }
    public float KnightStamina
    {
        get { return _KnightStamina; }
        set { _KnightStamina = value; }
    }
    public float KnightHealth
    {
        get { return _KnightHealth; }
        set { _KnightHealth = value; }
    }
    public float KnightArmor
    {
        get { return _KnightArmor; }
        set { _KnightArmor = value; }
    }
    public int KnightWeapon
    {
        get { return _KnightWeapon; }
        set { _KnightWeapon = value; }
    }
    public float ArcherDamage
    {
        get { return _ArcherDamage; }
        set { _ArcherDamage = value; }
    }
    public float ArcherStamina
    {
        get { return _ArcherStamina; }
        set { _ArcherStamina = value; }
    }
    public float ArcherHealth
    {
        get { return _ArcherHealth; }
        set { _ArcherHealth = value; }
    }
    public float ArcherArmor
    {
        get { return _ArcherArmor; }
        set { _ArcherArmor = value; }
    }
    public int ArcherWeapon
    {
        get { return _ArcherWeapon; }
        set { _ArcherWeapon = value; }
    }
    public float ThiefDamage
    {
        get { return _ThiefDamage; }
        set { _ThiefDamage = value; }
    }
    public float ThiefStamina
    {
        get { return _ThiefStamina; }
        set { _ThiefStamina = value; }
    }
    public float ThiefHealth
    {
        get { return _ThiefHealth; }
        set { _ThiefHealth = value; }
    }
    public float ThiefArmor
    {
        get { return _ThiefArmor; }
        set { _ThiefArmor = value; }
    }
    public int ThiefWeapon
    {
        get { return _ThiefWeapon; }
        set { _ThiefWeapon = value; }
    }
    public float OrcDamage
    {
        get { return _OrcDamage; }
        set { _OrcDamage = value; }
    }
    public float OrcStamina
    {
        get { return _OrcStamina; }
        set { _OrcStamina = value; }
    }
    public float OrcHealth
    {
        get { return _OrcHealth; }
        set { _OrcHealth = value; }
    }
    public float OrcArmor
    {
        get { return _OrcArmor; }
        set { _OrcArmor = value; }
    }
    public int OrcWeapon
    {
        get { return _OrcWeapon; }
        set { _OrcWeapon = value; }
    }
    public float TrollDamage
    {
        get { return _TrollDamage; }
        set { _TrollDamage = value; }
    }
    public float TrollStamina
    {
        get { return _TrollStamina; }
        set { _TrollStamina = value; }
    }
    public float TrollHealth
    {
        get { return _TrollHealth; }
        set { _TrollHealth = value; }
    }
    public float TrollArmor
    {
        get { return _TrollArmor; }
        set { _TrollArmor = value; }
    }
    public int TrollWeapon
    {
        get { return _TrollWeapon; }
        set { _TrollWeapon = value; }
    }
    public float SlimeDamage
    {
        get { return _SlimeDamage; }
        set { _SlimeDamage = value; }
    }
    public float SlimeStamina
    {
        get { return _SlimeStamina; }
        set { _SlimeStamina = value; }
    }
    public float SlimeHealth
    {
        get { return _SlimeHealth; }
        set { _SlimeHealth = value; }
    }
    public float SlimeArmor
    {
        get { return _SlimeArmor; }
        set { _SlimeArmor = value; }
    }
    public int SlimeWeapon
    {
        get { return _SlimeWeapon; }
        set { _SlimeWeapon = value; }
    }

    public float KimDamage
    {
        get { return _KimDamage; }
        set { _KimDamage = value; }
    }
    public float KimStamina
    {
        get { return _KimStamina; }
        set { _KimStamina = value; }
    }
    public float KimHealth
    {
        get { return _KimHealth; }
        set { _KimHealth = value; }
    }
    public float KimArmor
    {
        get { return _KimArmor; }
        set { _KimArmor = value; }
    }
    public int KimWeapon
    {
        get { return _KimWeapon; }
        set { _KimWeapon = value; }
    }
    public int isOp
    {
        get { return _isOp; }
        set { _isOp = value; }
    }
    public string OpWeaponName
    {
        get { return _OpWeaponName; }
        set { _OpWeaponName = value; }
    }
    public string OpArmorName
    {
        get { return _OpArmorName; }
        set { _OpArmorName = value; }
    }
    public int OpWeaponStats
    {
        get { return _OpWeaponStats; }
        set { _OpWeaponStats = value; }
    }
    public int OpArmorStats
    {
        get { return _OpArmorStats; }
        set { _OpArmorStats = value; }
    }
    public int OpMoney
    {
        get { return _OpMoney; }
        set { _OpMoney = value; }
    }
    public int OpHeal
    {
        get { return _OpHeal; }
        set { _OpHeal = value; }
    }
    public int BlockDamageRecover
    {
        get { return _BlockDamageRecover; }
        set { _BlockDamageRecover = value; }
    }
}



using UnityEngine;
public class WeaponConstructor
{
    private WeaponView _weaponBase;

    public void Init()
    {
        _weaponBase = GameLayer.Instance.ResourceManager.WeaponBase;
    }

    public WeaponModel CreateWeapon(string type)
    {
        var weapon = Object.Instantiate(_weaponBase);
        WeaponData data = GameLayer.Instance.BalanceData.WeaponsData.Find(ch => ch.Type == type);
        WeaponModel model = new WeaponModel(data);
        weapon.Init(model);
        return model;
    }

}

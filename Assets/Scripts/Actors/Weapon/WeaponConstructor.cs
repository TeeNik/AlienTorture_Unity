using UnityEngine;
public class WeaponConstructor
{
    private WeaponView _weaponBase;

    public WeaponModel CreateWeapon(string type)
    {
        var prefab = GameLayer.Instance.ResourceManager.GetWeaponPrefab(type);
        WeaponData data = GameLayer.Instance.BalanceData.WeaponsData.Find(ch => ch.Type == type);
        var weapon = Object.Instantiate(prefab);
        var model = weapon.gameObject.AddComponent<WeaponModel>();
        weapon.Init(model);
        model.Init(data);
        return model;
    }

}

using UnityEngine;
public class WeaponConstructor : MonoBehaviour
{
    [SerializeField] private WeaponView _weaponBase;


    public void Init()
    {
       
    }

    public WeaponModel CreateWeapon(string type)
    {
        var weapon = Instantiate(_weaponBase);
        WeaponData data = GameLayer.Instance.BalanceData.WeaponsData.Find(ch => ch.Type == type);
        WeaponModel model = new WeaponModel(data);
        weapon.Init(model);
        return model;
    }

}

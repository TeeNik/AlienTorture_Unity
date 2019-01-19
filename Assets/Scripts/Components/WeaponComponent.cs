using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : BaseComponent
{
    public WeaponModel Weapon;
    private float _lastShootTime;
    private Transform _weaponContainer;


    public void Init(CharacterModel owner, Transform weaponContainer)
    {
        base.Init(owner);
        _weaponContainer = weaponContainer;
        SetWeapon("Pistol");
    }

    public void SetWeapon(string id)
    {
        Weapon = GameLayer.Instance.WeaponConstructor.CreateWeapon(id);
        Weapon.transform.SetParent(_weaponContainer);
    }


    public void RotateWeapon()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = 180 * Mathf.Atan2(mousePosition.y, mousePosition.x) / Mathf.PI; ;
        int horizontalDirection = (mousePosition.x > 0) ? 1 : -1;
        transform.rotation = Quaternion.Euler(0, 90 - horizontalDirection * 90, -90 + horizontalDirection * (90 + angle));
    }

    public void Shoot()
    {
        if (Time.time > _lastShootTime)
        {
            _lastShootTime = Time.time + Weapon.Data.Rate;
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            var bullet = GameLayer.Instance.BulletPool.GetBullet();
            bullet.Run(Weapon.transform.position, direction, Weapon.Data.Damage);
        }
    }
}

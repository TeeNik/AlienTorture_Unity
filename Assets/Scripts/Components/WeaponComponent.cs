using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour
{
    public WeaponModel Weapon;
    public GameObject bigWeaponSpot, pistolSpot;
    private GameObject _currentWeapon;
    public int damage;
    private float _lastShootTime,_shootRate;
    //private void Start()
    //{
    //    Weapon = GameLayer.Instance.WeaponConstructor.CreateWeapon("pistol");
    //    damage = (int)Weapon.Data.Damage;
    //    _shootRate = Weapon.Data.Rate;
    //    Debug.Log(_shootRate);
    //    _currentWeapon = pistolSpot;
    //}

    public void SetWeapon(string id)
    {

    }

    public void Shoot()
    {
        if (Time.time > _lastShootTime)
        {
            _lastShootTime = Time.time + _shootRate;
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            var bullet = GameLayer.Instance.BulletPool.GetBullet();
            bullet.Run(_currentWeapon.transform.position, direction, damage);
        }
    }
}

using System;
using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    public WeaponData Data { get; private set; }

    private int _maxInMag; //ToConfig
    private int _currentInMag;
    private int _currentAmmo;
    private int _maxAmmo; //ToConfig

    public void Init(WeaponData data)
    {
        Data = data;
    }
}

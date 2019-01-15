using System;
using UnityEngine;

public class WeaponModel 
{
    //public GameObject Object;
    public WeaponData Data { get; private set; }

    public WeaponModel(WeaponData data)
    {
        Data = data;
    }
}

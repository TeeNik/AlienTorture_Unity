using System;
using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    public WeaponData Data { get; private set; }

    public void Init(WeaponData data)
    {
        Data = data;
    }
}

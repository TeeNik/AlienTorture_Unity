using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponView : MonoBehaviour
{
    private WeaponModel _model;

    public void Init(WeaponModel model)
    {
        _model = model;
    }
}

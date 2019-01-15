using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponView : MonoBehaviour
{
    private WeaponModel _model;
    // Start is called before the first frame update

    public void Init(WeaponModel model)
    {
        _model = model;
    }
}

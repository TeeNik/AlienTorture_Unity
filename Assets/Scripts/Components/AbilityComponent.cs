using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityComponent : MonoBehaviour
{

    private Ability _ability;

    public void Init()
    {
        //_ability = (Ability)Activator.CreateInstance(_abilities[data.Ability]);
        //model.Ability.Init(model.Object.transform);
    }

    public void Use()
    {
        _ability.Use();
    }

}

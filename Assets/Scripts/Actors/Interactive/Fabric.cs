using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabric : Interactive
{
    private float _progress;

    public override void Process(Interactive obj)
    {
        Hands hands = obj as Hands;
    }
}

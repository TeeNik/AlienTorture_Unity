using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : Interactive
{
    public Transform Container;
    public bool IsEmpty => InHands == null;
    public Interactive InHands { get; private set; }

    private readonly Vector2 _size = new Vector2(.2f, .2f);

    public override void Process(Interactive obj)
    {
        obj.transform.localScale = _size;
        obj.transform.SetParent(Container);
        obj.transform.localPosition = Vector3.zero;
        InHands = obj;
    }

    public Interactive TakeFromHands()
    {
        var obj = InHands;
        InHands = null;
        return obj;
    }
}

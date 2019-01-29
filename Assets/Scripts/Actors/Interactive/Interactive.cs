using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    public abstract void Select();
    public abstract void Deselect();
    public abstract void Execute(Interactive obj);

}

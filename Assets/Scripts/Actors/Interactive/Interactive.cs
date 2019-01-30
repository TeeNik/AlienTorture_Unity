using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    public virtual bool IsContinuous { get; set; }
    public abstract void Select();
    public abstract void Deselect();
    public abstract void Execute(Interactive obj);

}

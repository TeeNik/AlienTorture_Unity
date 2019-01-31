using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;

    public virtual bool IsContinuous { get; set; }

    public virtual void Select()
    {
        SpriteRenderer.color = new Color(1,1,1, .9f);
    }

    public virtual void Deselect()
    {
        SpriteRenderer.color = Color.white;
    }

    public abstract void Execute(Interactive obj);

}

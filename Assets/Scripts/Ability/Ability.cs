using UnityEngine;

public abstract class Ability
{
    protected Animator _animator;
    public abstract void Use();
    public abstract void Init(Transform tr);
    public virtual string Name { get; }
}
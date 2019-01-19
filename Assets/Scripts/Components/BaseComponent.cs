using UnityEngine;
public class BaseComponent : MonoBehaviour
{
    public virtual void Init(CharacterModel owner)
    {
        Owner = owner;
    }

    protected CharacterModel Owner { get; private set; }
}

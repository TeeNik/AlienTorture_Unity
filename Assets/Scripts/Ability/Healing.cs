using System.Collections;
using UnityEngine;

public class Healing : Ability
{
    public override void Init(Transform tr)
    {
        GameObject Aura = Object.Instantiate(GameLayer.Instance.ResourceManager.GetAbilityPrefab(Name));
        Aura.transform.parent = tr;
        _animator = Aura.GetComponent<Animator>();
    }

    public sealed override string Name => "Aura";

    public override void Use()
    {
        _animator.SetTrigger("heal");
        GameLayer.Instance.Messages.OnNext(new HealthChangeMsg{Value = -2});
    }
}
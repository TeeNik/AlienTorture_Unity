using UnityEngine;

public sealed class BlastRing : Ability
{
    public override void Init(Transform tr)
    {
        GameObject ring = Object.Instantiate(GameLayer.Instance.ResourceManager.GetAbilityPrefab(Name));
        ring.transform.parent = tr;
        _animator = ring.GetComponent<Animator>();
    }
    public override void Use ()
    {
        _animator.SetTrigger("blow");
    }
    public override string Name => "Blastring";
}
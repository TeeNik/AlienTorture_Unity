using System.Collections;
using UnityEngine;

public sealed class Rage : Ability
{
    public override void Init(Transform tr)
    {
        GameObject rageAura = Object.Instantiate(GameLayer.Instance.ResourceManager.GetAbilityPrefab(Name));
        rageAura.transform.parent = tr;
        _animator = rageAura.GetComponent<Animator>();
    }

    IEnumerator RageRoutine(Animator animator)
    {
        //TODO
        var pc = GameLayer.Instance.Player.CurrentValue.Object.GetComponent<PlayerController>();
        pc.DamageModifier = 2;
        animator.SetBool("raged", true);
        yield return new WaitForSeconds(5);
        pc.DamageModifier = 1;
        animator.GetComponent<Animator>().SetBool("raged", false);
    }
    public override void Use()
    {
        GameLayer.Instance.StartCoroutine(RageRoutine(_animator));
    }
    public override string Name => "Aura";
}
using System.Collections;
using UnityEngine;

public sealed class Rage : Ability
{
    public override void Init(Transform tr)
    {
        GameObject Aura = Object.Instantiate(GameLayer.Instance.ResourceManager.GetAbilityPrefab(Name));
        Aura.transform.parent = tr;
        _animator = Aura.GetComponent<Animator>();
    }

    IEnumerator RageRoutine(Animator animator)
    {
        //TODO
        var wc = Game.Get().Player.CurrentValue.WeaponComp;
        wc.Weapon.Data.Damage *= 2;
        animator.SetBool("raged", true);
        yield return new WaitForSeconds(5);
        wc.Weapon.Data.Damage /= 2;
        animator.GetComponent<Animator>().SetBool("raged", false);
    }
    public override void Use()
    {
        GameLayer.Instance.StartCoroutine(RageRoutine(_animator));
    }
    public override string Name => "Aura";
}
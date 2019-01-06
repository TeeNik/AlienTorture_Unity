using System.Collections;
using UnityEngine;

public class Shield :Ability
{
    public override void Init(Transform tr)
    {
        GameObject shieldAura = Object.Instantiate(GameLayer.Instance.ResourceManager.GetAbilityPrefab(Name));
        shieldAura.transform.parent = tr;
        _animator = shieldAura.GetComponent<Animator>();
    }

    public sealed override string Name => "Blastring";

    public IEnumerator ShieldRoutine(Animator animator)
    {
        animator.SetBool("shield", true);
        yield return new WaitForSeconds(5);
        animator.GetComponent<Animator>().SetBool("shield", false);
    }
    public override void Use()
    {
        GameLayer.Instance.StartCoroutine(ShieldRoutine(_animator));
        Debug.Log("Shield");
    }
}
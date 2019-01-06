using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
   void Use();
}
public class BlastRing : IAbility
{
    public BlastRing(GameObject Prefab)
    {
        _animator = Prefab.GetComponent<Animator>();
    }
    Animator _animator;
    public void Use ()
    {
        _animator.SetTrigger("blow");
    }
}

public class Rage : IAbility
{
    public Rage(GameObject Prefab)
    {
        _animator = Prefab.GetComponent<Animator>();
    }
    IEnumerator RageRoutine(Animator animator)
    {

        GameLayer.Instance.Player.CurrentValue.Object.GetComponent<PlayerController>().DamageModifier = 2;
        animator.SetBool("raged", true);
        yield return new WaitForSeconds(5);
        GameLayer.Instance.Player.CurrentValue.Object.GetComponent<PlayerController>().DamageModifier = 1;
        animator.GetComponent<Animator>().SetBool("raged", false);
    }
    Animator _animator;
    public void Use()
    {
        GameLayer.Instance.StartCoroutine(RageRoutine(_animator));
        Debug.Log("Rage");
    }    
}

public class Shield :IAbility
{
    public Shield(GameObject Prefab)
    {
        _animator = Prefab.GetComponent<Animator>();
    }
    public IEnumerator ShieldRoutine(Animator animator)
    {
        animator.SetBool("shield", true);
        yield return new WaitForSeconds(5);
        animator.GetComponent<Animator>().SetBool("shield", false);
    }
    Animator _animator;
    public void Use()
    {
        GameLayer.Instance.StartCoroutine(ShieldRoutine(_animator));
        Debug.Log("Shield");
    }
}





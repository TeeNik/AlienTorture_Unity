using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ablilties : MonoBehaviour
{
    public GameObject Blast,Aura;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator Shield(Animator animator)
    {
        animator.SetBool("shield", true);
        yield return new WaitForSeconds(5);
        animator.GetComponent<Animator>().SetBool("shield", false);
    }
    IEnumerator Rage(Animator animator)
    {
        GetComponent<PlayerController>().DamageModifier = 2;
        Aura.GetComponent<Animator>().SetBool("raged", true);
        yield return new WaitForSeconds(5);
        GetComponent<PlayerController>().DamageModifier = 1;
        Aura.GetComponent<Animator>().SetBool("raged", false);
    }
    void BlastRing()
    {
        Blast.GetComponent<Animator>().SetTrigger("blow");
    }

}

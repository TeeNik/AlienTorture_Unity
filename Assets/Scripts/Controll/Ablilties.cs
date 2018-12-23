using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ablilties : MonoBehaviour
{
    public GameObject Blast,Aura;
    private float rageEndTime,shieldEndTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Rage();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            BlastRing();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Shield();
        if (Time.time < rageEndTime)
            GetComponent<PlayerController>().DamageModifier = 2;
        else
            GetComponent<PlayerController>().DamageModifier = 1;
        Aura.GetComponent<Animator>().SetBool("raged", Time.time < rageEndTime);
        Aura.GetComponent<Animator>().SetBool("shield", Time.time < shieldEndTime);
    }
    void Rage()
    {
        rageEndTime = Time.time + 5;
    }
    void BlastRing()
    {
        Blast.GetComponent<Animator>().SetTrigger("blow");
    }
    void Shield()
    {
        shieldEndTime = Time.time + 5;
    }
}

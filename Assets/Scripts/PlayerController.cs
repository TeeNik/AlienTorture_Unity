using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    public float Speed = 50f;
    Rigidbody2D body;
    Animator anim;
    bool looksRight = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal, vertical).normalized * Speed;
        anim.SetFloat("Speed", body.velocity.magnitude);
        if ((body.velocity.x > 0 && !looksRight) || (body.velocity.x < 0 && looksRight))
            Flip();
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        looksRight = !looksRight;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : BaseComponent
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private float _speed = 6f;
    private bool _looksRight = true;

    public override void Init(CharacterModel owner)
    {
        base.Init(owner);
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void Move(float vertical, float horizontal)
    {
        _rb.velocity = new Vector2(horizontal, vertical).normalized * _speed;
        _animator.SetFloat("Speed", _rb.velocity.magnitude);
    }

    public void Flip()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (mousePosition.x > 0 && !_looksRight || mousePosition.x < 0 && _looksRight)
        {
            transform.Rotate(0, 180, 0);
            _looksRight = !_looksRight;
        }
    }
}

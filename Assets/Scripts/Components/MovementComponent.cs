using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : BaseComponent
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private float _speed = 6f;
    private bool _looksRight = true;
    int _previousDirection;
    enum Directions {Right,Left,Up,Down };
    public override void Init(CharacterModel owner)
    {
        base.Init(owner);
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void Move(float vertical, float horizontal)
    {
        _rb.velocity = new Vector2(horizontal, vertical).normalized * _speed;
        //  _animator.SetFloat("Speed", _rb.velocity.magnitude)
        CheckDirection();
    }

    void CheckDirection()
    {
        Vector2 velocity = _rb.velocity;
        if (Mathf.Abs(velocity.x) >= Mathf.Abs(velocity.y))
        {
            if (velocity.x > 0 && _previousDirection!=(int)Directions.Right)
            {
                _animator.SetTrigger("Right");
                _previousDirection = (int)Directions.Right;
            }
            if (velocity.x < 0 && _previousDirection != (int)Directions.Left)
            {
                _animator.SetTrigger("Left");
                _previousDirection = (int)Directions.Left;
            }
        }
        else
        {
            if (velocity.y > 0 && _previousDirection != (int)Directions.Up)
            {
                _animator.SetTrigger("Up");
                _previousDirection = (int)Directions.Up;
            }
            if (velocity.y < 0 && _previousDirection != (int)Directions.Down)
            {
                _animator.SetTrigger("Down");
                _previousDirection = (int)Directions.Down;
            }
        }
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

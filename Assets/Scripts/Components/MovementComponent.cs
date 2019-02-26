using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : BaseComponent
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private float _speed = 6f;
    private bool _looksRight = true;
    private Direction _previousDirection=Direction.Right;

    enum Direction
    {
        Right,Left,Up,Down
    }

    public override void Init(CharacterModel owner)
    {
        base.Init(owner);
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void Move(float vertical, float horizontal)
    {
        bool walked = _rb.velocity.magnitude>0.2;
        Debug.Log(walked.ToString() + " " + Time.time.ToString());
        _rb.velocity = new Vector2(horizontal, vertical).normalized * _speed;
        CheckDirections();
        CheckIfMoving(walked);        
    }

    void CheckIfMoving(bool walked)
    {
        if (_rb.velocity.magnitude > 0 && !walked || _rb.velocity.magnitude == 0 && walked)
        {
            _animator.SetTrigger(_previousDirection.ToString());
            _animator.SetFloat("Speed", _rb.velocity.magnitude);
        }
    }

    void CheckDirections()
    {
        float x = _rb.velocity.x;
        float y = _rb.velocity.y;

        if (Mathf.Abs(x) >= Mathf.Abs(y))
        {
            CheckDirection(x, Direction.Left, Direction.Right);
        }
        else
        {
            CheckDirection(y, Direction.Down, Direction.Up);
        }
    }

    private void CheckDirection(float coor, Direction less, Direction more)
    {
        if (coor > 0 && _previousDirection != more)
        {
            SetDirection(more);
        }
        if (coor < 0 && _previousDirection != less)
        {
            SetDirection(less);
        }
    }

    private void SetDirection(Direction dir)
    {
            _animator.SetTrigger(dir.ToString());
            _previousDirection = dir;
    }


}

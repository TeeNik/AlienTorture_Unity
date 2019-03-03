using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : BaseComponent
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private float _speed = 6f;
    private bool _looksRight = true;
    private Direction _previousDirection=Direction.Right, _directionOnCollision;
    private Vector3 _previousPosition, _currentPosition;
    enum Direction
    {
        Right,Left,Up,Down
    }

    public override void Init(CharacterModel owner)
    {
        base.Init(owner);
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentPosition = transform.position;
        _previousPosition = _currentPosition;
    }

    public void Move(float vertical, float horizontal)
    {
        _currentPosition = transform.position;
        bool walked = (_currentPosition - _previousPosition).magnitude>0.0000001;        
        _rb.velocity = new Vector2(horizontal, vertical).normalized * _speed;
        if(walked)
        CheckDirections();
        // CheckIfMoving(walked);
        _animator.SetBool("Walks",_rb.velocity.magnitude>0);
        Debug.Log(walked.ToString() + " " + (_currentPosition - _previousPosition).magnitude*100 + " " + Time.time);
        _previousPosition = _currentPosition;
    }

    void CheckIfMoving(bool walked)
    {
        if (_rb.velocity.magnitude > 0 && !walked || _rb.velocity.magnitude == 0 && walked)
        {
            _animator.SetTrigger(_previousDirection.ToString());
            _animator.SetBool("Walk",walked);
        }
    }

    void CheckDirections()
    {
        float x = _rb.velocity.x;
        float y = _rb.velocity.y;

        if (Mathf.Abs(x) >= Mathf.Abs(y))
        {
            CheckDirection(x, Direction.Left, Direction.Right, "Right",true);
        }
        else
        {
            CheckDirection(y, Direction.Down, Direction.Up,"Up",false);
        }
    }

    private void CheckDirection(float coor, Direction less, Direction more,string Parameter,bool isHorizontal)
    {
        if (coor > 0 && _previousDirection != more)
        {
            SetDirection(more);
            _animator.SetBool(Parameter, true);
            _animator.SetBool("Horizontal", isHorizontal);
        }
        if (coor < 0 && _previousDirection != less)
        {
            SetDirection(less);
            _animator.SetBool(Parameter, false);
            _animator.SetBool("Horizontal", isHorizontal);
        }
    }

    private void SetDirection(Direction dir)
    {
            //_animator.SetTrigger(dir.ToString());
            _previousDirection = dir;
    }


}

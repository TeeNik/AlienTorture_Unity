using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float _speed = 5f;
    private float _shootRate = .5f;
    private float _lastShootTime;
    private Rigidbody2D _rb;
    private Animator _animator;
    private bool _looksRight = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
        if (_rb.velocity.x > 0 && !_looksRight || _rb.velocity.x < 0 && _looksRight)
            Flip();
    }

    void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontal, vertical).normalized * _speed * 2;
        _animator.SetFloat("Speed", _rb.velocity.magnitude);
    }

    void Shoot()
    {
        if (Time.time > _lastShootTime)
        {
            _lastShootTime = Time.time + _shootRate;
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();

            var bullet = GameLayer.Instance.BulletPool.GetBullet();
            bullet.Run(transform.position, direction);
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        _looksRight = !_looksRight;
    }
}

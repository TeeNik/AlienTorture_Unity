using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float _speed = 5f;
    private float _shootRate = .5f;
    private float _lastShootTime;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update () {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal, vertical).normalized * _speed * 2;
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
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
}

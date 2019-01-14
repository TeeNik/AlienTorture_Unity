using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CompositeDisposable _subscriptions;
    private MovementComponent _movement;
    private bool _inited;

    private float _shootRate = .5f;
    private float _lastShootTime;
    private GameObject _activeWeapon;
    public float DamageModifier=1;



    void Start()
    {
        _subscriptions = new CompositeDisposable();
        _subscriptions.Add(GameLayer.Instance.Player.Subscribe(OnPlayerCreated));
        _activeWeapon = GetComponent<Transform>().GetChild(0).gameObject;
    }

    private void OnPlayerCreated(CharacterModel model)
    {
        _movement = model.MovementComp;
        _inited = true;
    }

    void Update()
    {
        if (_inited)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }

            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            _movement.Move(vertical, horizontal);
            _movement.Flip();

            if (Input.GetButtonDown("Jump"))
            {
                Ability();
            }
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
            bullet.Run(_activeWeapon.transform.position, direction,DamageModifier);
        }
    }
    void Ability()
    {
        GameLayer.Instance.Player.CurrentValue.Ability.Use();
    }
}

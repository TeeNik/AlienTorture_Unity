using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CompositeDisposable _subscriptions;
    private MovementComponent _movement;
    private WeaponComponent _weapon;
    private bool _inited;
    private float _lastShootTime, _shootRate=0.5f;

    void Start()
    {
        _subscriptions = new CompositeDisposable();
        _subscriptions.Add(GameLayer.Instance.Player.Subscribe(OnPlayerCreated));
    }

    private void OnPlayerCreated(CharacterModel model)
    {
        _movement = model.MovementComp;
        _weapon = model.WeaponComp;
        _inited = true;
    }

    void Update()
    {
        if (_inited)
        {
            if (Input.GetButton("Fire1"))
            {
                _weapon.Shoot();
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

    void Ability()
    {
        GameLayer.Instance.Player.CurrentValue.Ability.Use();
    }

    void OnDestroy()
    {
        Utils.DisposeAndSetNull(ref _subscriptions);
    }
}

using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CompositeDisposable _subscriptions;
    private MovementComponent _movement;
    private bool _inited;
    private float _lastShootTime, _shootRate=0.5f;

    void Start()
    {
        _subscriptions = new CompositeDisposable();
        _subscriptions.Add(Game.Get().Player.Subscribe(OnPlayerCreated));
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
            
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            _movement.Move(vertical, horizontal);
         
            if (Input.GetButtonDown("Jump"))
            {
            }
        }
    }

    void OnDestroy()
    {
        Utils.DisposeAndSetNull(ref _subscriptions);
    }
}

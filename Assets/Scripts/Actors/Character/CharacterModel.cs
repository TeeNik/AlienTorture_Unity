using System;
using UnityEngine;

public class CharacterModel : MonoBehaviour, IDisposable
{
    public void Init(CharacterData data)
    {
        Data = data;
        _subscriptions = new CompositeDisposable();
        MovementComp = gameObject.AddComponent<MovementComponent>();
        WeaponComp = gameObject.AddComponent<WeaponComponent>();
        MovementComp.Init(this);
        WeaponComp.Init(this, _weaponContainer);
    }

    private CompositeDisposable _subscriptions;

    public CharacterData Data { get; private set; }
    public MovementComponent MovementComp { get; private set; }
    public WeaponComponent WeaponComp { get; private set; }

    [SerializeField] private Transform _weaponContainer;

    public void Dispose()
    {
        Utils.DisposeAndSetNull(ref _subscriptions);
    }

    private Interactive _target;
    //TODO make hands class
    private CanTake _inHands;

    void OnTriggerEnter2D(Collider2D col)
    {
        var obj = col.GetComponent<Interactive>();
        if (obj != null && _target != obj)
        {
            if (_target != null)
            {
                _target.Deselect();
                _target = null;
            }
            _target = obj;
            _target.Select();
        }
        print(col.gameObject.name);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        var obj = col.GetComponent<Interactive>();
        if (obj == _target && _target != null)
        {
            _target.Deselect();
            _target = null;
        }
        print(col.gameObject.name);
    }

    void UseTarget()
    {
        if (_target != null)
        {
            _target.Execute(_inHands);
        }
    }
}

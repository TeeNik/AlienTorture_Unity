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

    void OnTriggerEnter2D(Collider2D col)
    {
        print(col.gameObject.name);
    }
}

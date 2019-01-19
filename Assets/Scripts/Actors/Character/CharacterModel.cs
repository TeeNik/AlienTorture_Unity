using System;
using UnityEngine;

public class CharacterModel : MonoBehaviour, IDisposable
{
    public void Init(CharacterData data)
    {
        Data = data;
        _subscriptions = new CompositeDisposable();
        HealthComp = gameObject.AddComponent<HealthComponent>();
        MovementComp = gameObject.AddComponent<MovementComponent>();
        WeaponComp = gameObject.AddComponent<WeaponComponent>();
        HealthComp.Init(this);
        MovementComp.Init(this);
        WeaponComp.Init(this, _weaponContainer);
    }

    private CompositeDisposable _subscriptions;

    public CharacterData Data { get; private set; }
    public MovementComponent MovementComp { get; private set; }
    public HealthComponent HealthComp { get; private set; }
    public WeaponComponent WeaponComp { get; private set; }
    public Ability Ability;

    [SerializeField] private Transform _weaponContainer;

    public void Dispose()
    {
        Utils.DisposeAndSetNull(ref _subscriptions);
    }
}

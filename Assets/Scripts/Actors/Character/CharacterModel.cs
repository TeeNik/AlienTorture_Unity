using System;
using UnityEngine;

public class CharacterModel : IDisposable
{

    public CharacterModel(CharacterData data, GameObject obj)
    {
        Data = data;
        Object = obj;
        _subscriptions = new CompositeDisposable();
        MovementComp = obj.GetComponent<MovementComponent>();
        MovementComp.Init();
        HealthComp = obj.GetComponent<HealthComponent>();
        HealthComp.Init(_subscriptions);
    }

    private CompositeDisposable _subscriptions;

    public CharacterData Data { get; }
    public GameObject Object { get; } 
    public MovementComponent MovementComp { get; }
    public HealthComponent HealthComp { get; }

    public Ability Ability;
    public void Dispose()
    {
        Utils.DisposeAndSetNull(ref _subscriptions);
    }
}

using UnityEngine;

public class HealthComponent : BaseComponent
{
    public int MaxHealth;
    public UnityBehavior<int> Health { get; private set; }
    private CompositeDisposable _subscriptions;

    public override void Init(CharacterModel model)
    {
        base.Init(model);
        MaxHealth = 10;
        Health = new UnityBehavior<int>(MaxHealth);
        var messages = GameLayer.Instance.CurrentModel.CurrentValue.Messages;
        _subscriptions = new CompositeDisposable();
        _subscriptions.Add(messages.Subscribe<HealthChangeMsg>(OnHealthChangeMsg));
    }

    private void OnHealthChangeMsg(HealthChangeMsg msg)
    {
        ChangeHealth(msg.Value);   
    }

    public void ChangeHealth(int value)
    {
        int newHealth = Mathf.Clamp(Health.CurrentValue - value, 0, MaxHealth);
        Health.OnNext(newHealth);
        Debug.Log(Health.CurrentValue);
    }


}

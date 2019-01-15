using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int MaxHealth;
    public UnityBehavior<int> Health { get; private set; }

    public void Init(CompositeDisposable subscriptions)
    {
        MaxHealth = 10;
        Health = new UnityBehavior<int>(MaxHealth);
        var messages = GameLayer.Instance.Messages;
        subscriptions.Add(messages.Subscribe<HealthChangeMsg>(OnHealthChangeMsg));
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

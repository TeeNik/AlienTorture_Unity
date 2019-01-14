using UnityEngine;

public class CharacterModel
{

    public CharacterModel(CharacterData data, GameObject obj)
    {
        Data = data;
        Health = new UnityBehavior<int>(MaxHealth);
        Object = obj;
        MovementComp = obj.GetComponent<MovementComponent>();
        MovementComp.Init();
    }

    public CharacterData Data { get; }
    public UnityBehavior<int> Health { get; }
    public GameObject Object { get; } 
    public MovementComponent MovementComp { get; }


    public Ability Ability;   
    public void ChangeHealth (int Damage)
    {
        int newHealth = Mathf.Min(Health.CurrentValue - Damage, MaxHealth);      
        Health.OnNext(newHealth);
        Debug.Log(Health.CurrentValue);
    }
    //TODO Move to configs
    public int MaxHealth => 10;
}

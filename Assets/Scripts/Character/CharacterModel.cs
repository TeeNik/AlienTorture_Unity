using UnityEngine;

public class CharacterModel
{

    public CharacterModel(CharacterData data, GameObject obj)
    {
        Data = data;
        Health = new UnityBehavior<int>(MaxHealth);
        Object = obj;
    }

    public CharacterData Data { get; }
    public UnityBehavior<int> Health { get; }
    public GameObject Object { get; } 
    public Ability Ability;   
    //TODO Move to configs
    public int MaxHealth => 10;
}

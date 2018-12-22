using UnityEngine;

public class CharacterModel : MonoBehaviour
{

    public CharacterModel(CharacterData data)
    {
        Data = data;
        Health = new UnityBehavior<int>(10);
    }

    public CharacterData Data { get; }

    public UnityBehavior<int> Health { get; }

}

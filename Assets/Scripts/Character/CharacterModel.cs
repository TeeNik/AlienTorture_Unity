using UnityEngine;

public class CharacterModel : MonoBehaviour
{

    public CharacterModel(string type)
    {
        Type = type;
        Health = new UnityBehavior<int>(10);
    }

    public string Type { get; }

    public UnityBehavior<int> Health { get; }

}

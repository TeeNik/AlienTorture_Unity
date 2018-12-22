using UnityEngine;

public class CharacterConstructor : MonoBehaviour
{
    [SerializeField] private CharacterView _characterBase;

    public CharacterView CreateCharacter(string type, Transform parent)
    {
        var character = Instantiate(_characterBase, parent);
        CharacterData data = GameLayer.Instance.BalanceData.CharactersData.Find(ch => ch.Type == type);
        CharacterModel model = new CharacterModel(data);
        character.Init(model);
        return character;
    }
}

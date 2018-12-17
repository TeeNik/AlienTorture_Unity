using UnityEngine;

public class CharacterConstructor : MonoBehaviour
{
    [SerializeField] private CharacterView _characterBase;

    public void CreateCharacter(string type, Transform parent)
    {
        var character = Instantiate(_characterBase, parent);
        CharacterModel model = new CharacterModel("1");
        character.Init(model);
    }
}

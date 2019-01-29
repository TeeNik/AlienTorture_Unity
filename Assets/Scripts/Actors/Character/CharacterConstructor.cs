using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

public class CharacterConstructor
{
    private CharacterView _characterBase;

    public void Init()
    {
        _characterBase = GameLayer.Instance.ResourceManager.CharacterBase;
    }

    public CharacterModel CreateCharacter(string type, Transform parent)
    {
        var character = Object.Instantiate(_characterBase, parent);
        CharacterData data = GameLayer.Instance.BalanceData.CharactersData.Find(ch => ch.Type == type);

        CharacterModel model = character.gameObject.GetComponent<CharacterModel>();
        model.Init(data);
        character.Init(model);
        return model;
    }
}

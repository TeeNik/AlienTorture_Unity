using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class CharacterConstructor : MonoBehaviour
{
    private CharacterView _characterBase;
    private Dictionary<string, Type> _abilities;

    public void Init()
    {
        _characterBase = GameLayer.Instance.ResourceManager.CharacterBase;
        _abilities = new Dictionary<string, Type>();
        var abilityType = typeof(Ability);
        var abilities = Assembly.GetAssembly(abilityType).GetTypes().Where(t => t.IsClass && !t.IsAbstract && abilityType.IsAssignableFrom(t));
        foreach (Type type in abilities)
        {
            _abilities.Add(type.Name, type);
        }
    }

    public CharacterModel CreateCharacter(string type, Transform parent)
    {
        var character = Instantiate(_characterBase, parent);
        CharacterData data = GameLayer.Instance.BalanceData.CharactersData.Find(ch => ch.Type == type);
        CharacterModel model = new CharacterModel(data, character.gameObject);       
        character.Init(model);

        model.Ability = (Ability)Activator.CreateInstance(_abilities[data.Ability]);
        model.Ability.Init(model.Object.transform);
        return model;
    }

    public Type GetAbility(string name)
    {
        return _abilities[name];
    }
}

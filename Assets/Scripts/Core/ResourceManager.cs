using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    public Sprite[] CharacterSprites;
    public RuntimeAnimatorController[] CharacterAnimators;
    public GameObject[] AbilityPrefabs;
    public CharacterView CharacterBase;
    public WeaponView[] WeaponPrefabs;

    public GameObject GetAbilityPrefab(string name)
    {
        return Get(name,AbilityPrefabs);
    }

    public Sprite GetCharacterSprite(string name)
    {
        return Get(name, CharacterSprites);
    }

    public WeaponView GetWeaponPrefab(string name)
    {
        return Get(name, WeaponPrefabs);
    }

    public RuntimeAnimatorController GetCharacterAnimator(string name)
    {
        return Get(name, CharacterAnimators);
    }

    private T Get<T>(string Name, T[] Array) where T : Object
    {
        for (int i = 0; i < Array.Length; i++)
        {
            if (Array[i].name == Name)
            {
                return Array[i];
            }
        }
        return default(T);
    }
}

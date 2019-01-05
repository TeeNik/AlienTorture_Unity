using UnityEngine;

public class CharacterConstructor : MonoBehaviour
{
    [SerializeField] private CharacterView _characterBase;
    public CharacterModel CreateCharacter(string type, Transform parent)
    {
        var character = Instantiate(_characterBase, parent);
        CharacterData data = GameLayer.Instance.BalanceData.CharactersData.Find(ch => ch.Type == type);
        CharacterModel model = new CharacterModel(data, character.gameObject);       
        character.Init(model);
        switch (data.Ability)
        {
            case "rage":                
                GameObject rageAura = Instantiate(GameLayer.Instance.ResourceManager.GetAbilityPrefab("Aura"));
                rageAura.transform.parent = model.Object.transform;
                model.Ability = new Rage(rageAura);
                break;
            case "blastRing":
                GameObject Ring = Instantiate(GameLayer.Instance.ResourceManager.GetAbilityPrefab("Blastring"));
                Ring.transform.parent = model.Object.transform;
                model.Ability = new BlastRing(Ring);
                break;
            case "shield":
                GameObject shieldAura = Instantiate(GameLayer.Instance.ResourceManager.GetAbilityPrefab("Aura"));
                shieldAura.transform.parent = model.Object.transform;
                model.Ability = new Shield(shieldAura);
                break;
        }
        return model;
    }
}

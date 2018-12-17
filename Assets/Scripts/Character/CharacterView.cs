using UnityEngine;

public class CharacterView : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private Animator _animator;

    public void Init(CharacterModel model)
    {
        _sr.sprite = GameLayer.Instance.ResourceManager.GetCharacterSprite($"p{model.Type}_7");
        _animator.runtimeAnimatorController = GameLayer.Instance.ResourceManager.GetCharacterAnimator("Player" + model.Type);
    }

}

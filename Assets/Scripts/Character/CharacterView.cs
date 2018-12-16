using UnityEngine;

public class CharacterView : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private Animator _animator;


    //TODO replace with Model
    public void Init(string prefix)
    {
        _sr.sprite = GameLayer.Instance.ResourceManager.GetCharacterSprite($"p{prefix}_7");
        _animator.runtimeAnimatorController = GameLayer.Instance.ResourceManager.GetCharacterAnimator("Player" + prefix);
    }

}

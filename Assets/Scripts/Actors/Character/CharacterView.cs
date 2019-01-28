using System;
using UnityEngine;

public class CharacterView : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _healthBar;
    private CompositeDisposable _subscriptions;
    private CharacterModel _model;

    public void Init(CharacterModel model)
    {
        _model = model;
        var type = model.Data.Type;
        _sr.sprite = GameLayer.Instance.ResourceManager.GetCharacterSprite($"p{type}_8");
        _animator.runtimeAnimatorController = GameLayer.Instance.ResourceManager.GetCharacterAnimator("Player" + type);

        _subscriptions = new CompositeDisposable();
    }

    void OnDestroy()
    {
        Utils.DisposeAndSetNull(ref _subscriptions);
    }
}

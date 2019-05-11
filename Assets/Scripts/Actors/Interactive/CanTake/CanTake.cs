using UnityEngine;

public abstract class CanTake : Interactive
{
    [SerializeField] private Collider2D _collider;

    public override void Process(Interactive hands)
    {
        if (hands == null)
        {
            hands = this;
        }
    }

    public void SetColliderEnable(bool enable)
    {
        _collider.enabled = enable;
    }
}

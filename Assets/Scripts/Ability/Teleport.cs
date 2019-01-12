using UnityEngine;

public sealed class Teleport : Ability
{
    Camera _camera;
    public override void Init(Transform tr)
    {
        _camera = Camera.main;
    }
    public override void Use()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameLayer.Instance.Player.CurrentValue.Object.transform.position = new Vector3(target.x,target.y,0);
    }
  //  public override string Name => "Blastring";
}

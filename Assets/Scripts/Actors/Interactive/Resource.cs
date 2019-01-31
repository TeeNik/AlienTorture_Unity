using UnityEngine;

public class Resource : Interactive
{
    public Material Material;
    public Transform SpawnPoint;

    public override void Execute(Interactive obj)
    {
        var hands = obj as Hands;
        if (hands.IsEmpty)
        {
            Instantiate(Material, SpawnPoint);
        }
    }
}

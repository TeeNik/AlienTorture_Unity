using UnityEngine;

public class Table : Interactive
{
    public Transform Container;

    private Interactive _obj;

    public override void Process(Interactive obj)
    {
        if(obj.Type == InteractiveType.Hands)
        {
            Hands hands = obj as Hands;
            if (hands.IsEmpty)
            {
                hands.Process(_obj);
                Free();
            }
            else
            {
                Put(hands.TakeFromHands());

            }
        }
    }

    private void Put(Interactive obj)
    {
        var canTake = (CanTake) obj;
        canTake.SetColliderEnable(false);
        obj.transform.SetParent(Container);
        obj.transform.localPosition = Vector3.zero;
        _obj = obj;
    }

    private void Free()
    {
        _obj = null;
    }
}

public class FabricData
{
    public string InputType;
    public string Type;
    public float CraftTime;
}

public class Fabric : Interactive
{
    private float _progress;

    public FabricData Data { get; private set; }

    public override void Process(Interactive obj)
    {
        Hands hands = obj as Hands;
        if (!hands.IsEmpty)
        {
            if (hands.InHands.Type == Data.InputType)
            {

            }
        }
    }

    public void Put(Interactive obj)
    {

    }
}

using System.Collections;

public class FactoryData
{
    public string InputType;
    public string OutputType;
    public float CraftTime;
}

public class Factory : Interactive
{
    private float _progress;

    public FactoryData Data { get; private set; }
    public ProgressBar ProgressBar;

    public override void Process(Interactive obj)
    {
        Hands hands = obj as Hands;
        if (!hands.IsEmpty)
        {
            if (hands.InHands.Type == Data.InputType)
            {

            }
        }
        else
        {

        }
    }

    /*private IEnumerator CreateItem()
    {

    }*/ 

    public void Put(Interactive obj)
    {

    }
}

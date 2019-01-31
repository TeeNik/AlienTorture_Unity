public abstract class CanTake : Interactive
{
    public override void Execute(Interactive hands)
    {
        if (hands == null)
        {
            hands = this;
        }
    }
}

﻿public class CanTake : Interactive
{
    public override void Select()
    {
    }

    public override void Deselect()
    {
    }

    public override void Execute(Interactive hands)
    {
        if (hands == null)
        {
            hands = this;
        }
    }
}

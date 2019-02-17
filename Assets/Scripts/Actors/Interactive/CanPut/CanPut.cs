public abstract class CanPut : Interactive
{
    public Interactive Object;
    public bool IsFree => Object == null;

    public virtual void Put(Interactive obj)
    {
        Object = obj;
    }

    public virtual void Free(Interactive obj)
    {
        obj = null;
    }
}

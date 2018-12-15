using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Projectile _prefab;
    [SerializeField] private Transform _parent;

    private List<Projectile> _used;
    private List<Projectile> _free;

    private int _size = 200;
    private int _count;

    public void Init()
    {
        _used = new List<Projectile>();
        _free = new List<Projectile>();

        AddObjectsToPool(_size);
    }


    public Projectile GetBullet()
    {
        if (_free.Count == 0)
        {
            AddObjectsToPool(10);
        }

        var obj = _free[_free.Count - 1];
        _free.RemoveAt(_free.Count - 1);
        _used.Add(obj);
        obj.gameObject.SetActive(true);
        return obj;
    }

    public bool ReturnToPool(Projectile obj)
    {
        if (_used.Contains(obj))
        {
            _used.Remove(obj);
            _free.Add(obj);
            obj.gameObject.SetActive(false);
        }
        return false;
    }

    void AddObjectsToPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(_prefab, _parent);
            obj.gameObject.SetActive(false);
            _free.Add(obj);
        }
    }


}

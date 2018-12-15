using UnityEngine;

public class Projectile : MonoBehaviour
{

    public int Speed;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Run(Vector2 startPos, Vector2 direction)
    {
        transform.position = startPos;
        _rb.velocity = direction * Speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "")
        {
            GameLayer.Instance.BulletPool.ReturnToPool(this);
        }
    }

    void Stop()
    {

    }

}

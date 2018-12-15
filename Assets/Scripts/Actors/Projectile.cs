using UnityEngine;

public class Projectile : MonoBehaviour
{

    public int Speed;

    [SerializeField] private Rigidbody2D Rigidbody;


    public void Run(Vector2 startPos, Vector2 direction)
    {
        transform.position = startPos;
        Rigidbody.velocity = direction * Speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "")
        {
            Rigidbody.velocity = Vector2.zero;
            GameLayer.Instance.BulletPool.ReturnToPool(this);
        }
    }
}

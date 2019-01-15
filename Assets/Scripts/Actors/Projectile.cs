using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int _damage;
    public int Speed;
    [SerializeField] private Rigidbody2D Rigidbody;


    public void Run(Vector2 startPos, Vector2 direction,int weaponDamage)
    {
        _damage = weaponDamage;
        transform.position = startPos;
        Rigidbody.velocity = direction * Speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Rigidbody.velocity = Vector2.zero;
            GameLayer.Instance.BulletPool.ReturnToPool(this);
        }
    }
}

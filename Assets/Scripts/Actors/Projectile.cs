using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float Damage,_baseDamage=10;
    public int Speed;
    [SerializeField] private Rigidbody2D Rigidbody;


    public void Run(Vector2 startPos, Vector2 direction,float modifier)
    {
        Damage = modifier*_baseDamage;
        transform.position = startPos;
        Rigidbody.velocity = direction * Speed;
        print("Damage=" + Damage.ToString());
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

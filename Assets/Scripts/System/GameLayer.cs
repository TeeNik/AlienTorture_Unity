using UnityEngine;

public class GameLayer : MonoBehaviour
{
    public static GameLayer Instance;

    public BulletPool BulletPool;

    void Start()
    {
        Instance = this;

        BulletPool.Init();
    }

}

using UnityEngine;

public class GameLayer : MonoBehaviour
{
    public static GameLayer Instance;

    public BulletPool BulletPool;
    public ResourceManager ResourceManager;
    public CharacterConstructor CharacterConstructor;

    void Start()
    {
        Instance = this;

        BulletPool.Init();

        CharacterConstructor.CreateCharacter("1", transform);
    }

}

using UnityEngine;

public class GameLayer : MonoBehaviour
{
    public static GameLayer Instance;

    public BulletPool BulletPool;
    public ResourceManager ResourceManager;
    public CharacterConstructor CharacterConstructor;
    public SceneController SceneController;

    void Start()
    {
        Instance = this;

        BulletPool.Init();
        SceneController = new SceneController();

        CharacterConstructor.CreateCharacter("1", transform);
    }

}

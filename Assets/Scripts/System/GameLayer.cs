using UnityEngine;

public class GameLayer : MonoBehaviour
{
    [HideInInspector] public GameLayer Instance;

    void Start()
    {
        Instance = this;

    }

}

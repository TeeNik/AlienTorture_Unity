using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class GameLayer : MonoBehaviour
{
    public static GameLayer Instance;

    public BulletPool BulletPool;
    public ResourceManager ResourceManager;
    public CharacterConstructor CharacterConstructor;
    public SceneController SceneController;
    public BalanceData BalanceData;
    public GameObject Player;
    void Start()
    {
        Instance = this;

        BulletPool.Init();
        SceneController = new SceneController();
        BalanceData = new BalanceData();

        BalanceData.CharactersData = ParseConfig<CharacterData>("");
        Player =CharacterConstructor.CreateCharacter("1", transform).gameObject;

    }


    //TODO Remove later
    public List<T> ParseConfig<T>(string name)
    {
        var asset = Resources.Load("CharacterConfig") as TextAsset;
        return JsonConvert.DeserializeObject<List<T>>(asset.text);
    }
}

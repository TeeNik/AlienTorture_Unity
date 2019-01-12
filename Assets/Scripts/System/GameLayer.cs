using System;
using System.Collections;
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

    //TODO Replace to Model
    public UnityBehaviorEquals<CharacterModel> Player { get; private set; }
    public CommandSubject Messages { get; private set; }

    void Start()
    {
        Instance = this;

        Messages = new CommandSubject();
        BulletPool.Init();
        SceneController = new SceneController();
        BalanceData = new BalanceData();
        CharacterConstructor.Init();

        BalanceData.CharactersData = ParseConfig<CharacterData>();
        Player = new UnityBehaviorEquals<CharacterModel>(null);
        InitPlayer();
    }

    //TODO Remove later
    public void InitPlayer()
    {
        var player = CharacterConstructor.CreateCharacter("5", transform);
        Player.OnNext(player);
    }

    //TODO Remove later
    public List<T> ParseConfig<T>()
    {
        var asset = Resources.Load("CharacterConfig") as TextAsset;
        return JsonConvert.DeserializeObject<List<T>>(asset.text);
    }
}

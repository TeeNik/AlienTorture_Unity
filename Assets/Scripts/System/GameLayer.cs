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
    public WeaponConstructor WeaponConstructor;
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

        BalanceData.CharactersData = ParseConfig<CharacterData>("CharacterConfig");
        BalanceData.WeaponsData = ParseConfig<WeaponData>("WeaponConfig");
        
        Player = new UnityBehaviorEquals<CharacterModel>(null);

        gameObject.AddComponent<PlayerController>();
        InitPlayer();
    }

    //TODO Remove later
    public void InitPlayer()
    {
        var player = CharacterConstructor.CreateCharacter("1", transform);
        Player.OnNext(player);
    }

    //TODO Remove later
    public List<T> ParseConfig<T>(string fileName)
    {
        var asset = Resources.Load(fileName) as TextAsset;
        return JsonConvert.DeserializeObject<List<T>>(asset.text);
    }
}

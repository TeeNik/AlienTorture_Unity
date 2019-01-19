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

    public UnityBehaviorEquals<EnvironmentModel> CurrentModel { get; private set; }
    void Start()
    {
        Instance = this;

        CurrentModel = new UnityBehaviorEquals<EnvironmentModel>(null);
        BulletPool.Init();
        SceneController = new SceneController();
        BalanceData = new BalanceData();
        CharacterConstructor = new CharacterConstructor();
        CharacterConstructor.Init();
        WeaponConstructor = new WeaponConstructor();

        BalanceData.CharactersData = ParseConfig<CharacterData>("CharacterConfig");
        BalanceData.WeaponsData = ParseConfig<WeaponData>("WeaponConfig");

        ChangeCurrentModel(new GameModel());
    }

    private void OnLoaded(string s)
    {
        
    }

    public void ChangeCurrentModel(EnvironmentModel newModel)
    {
        CurrentModel.CurrentValue?.OnExit();
        CurrentModel.OnNext(newModel);
        newModel.OnEnter();
    }

    //TODO Remove later
    public List<T> ParseConfig<T>(string fileName)
    {
        var asset = Resources.Load(fileName) as TextAsset;
        return JsonConvert.DeserializeObject<List<T>>(asset.text);
    }
}

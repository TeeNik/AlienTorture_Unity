using System;
using System.Runtime.InteropServices.ComTypes;

public class GameModel : EnvironmentModel
{
    public UnityBehaviorEquals<CharacterModel> Player { get; private set; }

    private CommandSubject _messages;
    public CommandSubject Messages => _messages ?? (_messages = new CommandSubject());

    public void OnEnter()
    {
        Player = new UnityBehaviorEquals<CharacterModel>(null);
        GameLayer.Instance.SceneController.LoadScene("Level 1", true, s =>
        {
            GameLayer.Instance.gameObject.AddComponent<PlayerController>();
            InitPlayer();
        });
    }

    public void OnExit()
    {

    }

    public void InitPlayer()
    {
        var gameLayer = GameLayer.Instance;
        var player = gameLayer.CharacterConstructor.CreateCharacter("1", gameLayer.transform);
        Player.OnNext(player);
    }
}

public static class Game
{
    public static GameModel Get()
    {
        var model = GameLayer.Instance.CurrentModel.CurrentValue;
        Assert.Inv(model is GameModel, "Cannot get GameModel");
        var gameModel = model as GameModel;
        return gameModel;
    }
}

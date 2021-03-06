﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{

    public void LoadScene(string sceneName, bool additive, Action<string> onLoaded)
    {
        GameLayer.Instance.StartCoroutine(LoadSceneImpl(sceneName, additive, onLoaded));
    }

    private IEnumerator LoadSceneImpl(string sceneName, bool additive, Action<string> onLoaded)
    {
        var mode = additive ? LoadSceneMode.Additive : LoadSceneMode.Single;
        var operation = SceneManager.LoadSceneAsync(sceneName, mode);
        while (!operation.isDone)
        {
            yield return null;
        }
        onLoaded(sceneName);
    }

}

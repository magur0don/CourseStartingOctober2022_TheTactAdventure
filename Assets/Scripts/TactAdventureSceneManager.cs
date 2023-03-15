using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TactAdventureSceneManager : SingletonMonoBehaviour<TactAdventureSceneManager>
{
    public const string GameStartSceneName = "GameStart";
    public const string GameMainSceneName = "GameMain";
    public const string GameResultSceneName = "GameResult";

    /// <summary>
    /// 引数に入れられたシーンに遷移する
    /// </summary>
    /// <param name="sceneName"></param>
    public void SceneTransition(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

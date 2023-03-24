using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TactAdventureSceneManager : SingletonMonoBehaviour<TactAdventureSceneManager>
{
    public const string GameStartSceneName = "GameStart";
    public const string GameStageChoiceSceneName = "GameStageChoice";
    public const string GameMainSceneName = "GameMain";
    public const string GameResultSceneName = "GameResult";

    /// <summary>
    /// 引数に入れられたシーンに遷移する
    /// </summary>
    /// <param name="sceneName"></param>
    public void SceneTransition(string sceneName)
    {
        StartCoroutine(StartTransition(sceneName));
    }

    IEnumerator StartTransition(string sceneName)
    {
        SceneTransitionManager.Instance.FadeStates = SceneTransitionManager.FadeState.FadeOut;
        yield return new WaitWhile(()=> SceneTransitionManager.Instance.FadeStates == SceneTransitionManager.FadeState.FadeOut);
        yield return new WaitWhile(() => SceneTransitionManager.Instance.FadeStates == SceneTransitionManager.FadeState.FadeOutPostProcess);
        SceneManager.LoadScene(sceneName);
        SceneTransitionManager.Instance.FadeStates = SceneTransitionManager.FadeState.FadeIn;
    }

}

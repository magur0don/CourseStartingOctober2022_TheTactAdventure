using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStageChoiceSceneManager : MonoBehaviour
{
    private int choiceLevel = 0;

    private void Start()
    {
        TactAdventureSoundManager.Instance.PlayeBGM
            ( TactAdventureSoundManager.BGMType.StageChoiceBGM);
    }

    public void StartMainGame(int level)
    {
        choiceLevel = level;
        SceneManager.sceneLoaded += SceneLoaded;
        TactAdventureSceneManager.Instance.SceneTransition(TactAdventureSceneManager.GameMainSceneName);
    }

    // イベントハンドラー（イベント発生時に動かしたい処理）
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        GameSceneManager gameSceneManager = FindObjectOfType<GameSceneManager>();
        gameSceneManager.GameLevel = choiceLevel;

        // レベルを渡す処理をロード後の処理から消す
        SceneManager.sceneLoaded -= this.SceneLoaded;
    }
}

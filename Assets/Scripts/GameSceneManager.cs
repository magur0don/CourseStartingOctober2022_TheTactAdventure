using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public enum GameState
    {
        Invalide = -1,
        GameInit,
        GameStart,
        GamePlaying,
        GameOver
    }
    public GameState GameStates = GameState.Invalide;

    public CharacterParameterBase Player;

    public GameObject CheckPoint;

    public GameClearPoint GameClearPoint;

    public GameObject Enemy;

    public int GameLevel = 1;

    public List<Vector2> EnemyPos = new List<Vector2>();

    

    // プレイヤーが死んだらCheckPointから復活する
    private void Update()
    {
        switch (GameStates)
        {
            case GameState.Invalide:

                GameStates = GameState.GameInit;
                break;

            case GameState.GameInit:
                // ゲームレベルによって敵を増やす
                for (int i = 0; i < GameLevel; i++)
                {
                    if (EnemyPos[i] == null)
                    {
                        Debug.Log("そのレベルのPosがありません");
                    }
                    var enemy = Instantiate(Enemy);
                    enemy.transform.position = EnemyPos[i];

                }
                GameStates = GameState.GameStart;
                break;
            case GameState.GameStart:
                GameStates = GameState.GamePlaying;
                break;

            case GameState.GamePlaying:
                if (!Player.gameObject.activeSelf)
                {
                    Player.transform.position = CheckPoint.transform.position;
                    Player.Revival();
                    Player.gameObject.SetActive(true);
                }

                if (GameClearPoint.GameClear)
                {
                    GameStates = GameState.GameOver;
                }
                break;
            case GameState.GameOver:
                if (GameClearPoint.GameClear) {

                    TactAdventureSceneManager.Instance.SceneTransition(TactAdventureSceneManager.GameResultSceneName);
                    GameClearPoint.GameClear = false;

                }

                break;
        }
    }
}

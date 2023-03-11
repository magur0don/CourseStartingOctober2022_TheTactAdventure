using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public enum GameState {
        Invalide = -1,
        GameStart,
        GamePlaying,
        GameOver
    }
    public GameState GameStates = GameState.Invalide;

    public CharacterParameterBase Player;

    public CheckPoint CheckPoint;

    // プレイヤーが死んだらCheckPointから復活する
    private void Update()
    {

        switch (GameStates)
        {
            case GameState.Invalide:
                GameStates = GameState.GameStart;
                break;

            case GameState.GameStart:
                GameStates = GameState.GamePlaying;
                break;

            case GameState.GamePlaying:
                if (!Player.gameObject.activeSelf) {
                    Player.transform.position = CheckPoint.gameObject.transform.position;
                    Player.Revival();
                    Player.gameObject.SetActive(true);
                }
                break;
        }
    }
}

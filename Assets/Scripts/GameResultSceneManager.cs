using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultSceneManager : MonoBehaviour
{
    public void GameStartSceneTransition()
    {
        TactAdventureSceneManager.Instance.SceneTransition(TactAdventureSceneManager.GameStartSceneName);
    }
}

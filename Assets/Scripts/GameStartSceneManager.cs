using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartSceneManager : MonoBehaviour
{
    public void StartMainGame()
    {
        TactAdventureSceneManager.Instance.SceneTransition(TactAdventureSceneManager.GameMainSceneName);
    }
}

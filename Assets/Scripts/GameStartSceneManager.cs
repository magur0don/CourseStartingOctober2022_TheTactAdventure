using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartSceneManager : MonoBehaviour
{
    public void StageChoiceTransition()
    {
        TactAdventureSceneManager.Instance.SceneTransition(TactAdventureSceneManager.GameStageChoiceSceneName);
    }
}

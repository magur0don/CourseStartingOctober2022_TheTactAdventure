using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartSceneManager : MonoBehaviour
{

    private void Start()
    {
        TactAdventureSoundManager.Instance.PlayeBGM( TactAdventureSoundManager.BGMType.TitleBGM);
    }
    public void StageChoiceTransition()
    {
        TactAdventureSceneManager.Instance.SceneTransition(TactAdventureSceneManager.GameStageChoiceSceneName);
    }
}

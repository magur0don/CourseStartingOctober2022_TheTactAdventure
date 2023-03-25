using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleManager : SingletonMonoBehaviour<TimeScaleManager>
{
    public override void Awake()
    {
        // GameMainシーンの中のみで使用する
        isSceneinSingleton = true;
        base.Awake();
    }

    // タイムスケールを調整する
    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionManager : SingletonMonoBehaviour<SceneTransitionManager>
{
    [SerializeField]
    private Image transitionImage;

    public enum FadeState
    {
        Invalide = -1,      // 指定なし
        FadeIn,             // 次のシーンが現れる
        FadeInPostProcess,  // フェードインの後処理
        FadeOut,            // 次のシーンへ隠れる
        FadeOutPostProcess  // フェードインの後処理
    }

    public FadeState FadeStates = FadeState.Invalide;

    private Color alphaColor;

    private void Update()
    {
        FaderAction();   
    }

    private void FaderAction()
    {
        switch (FadeStates)
        {
            case FadeState.Invalide:
                // 何もしない
                break;
            case FadeState.FadeIn:
                transitionImage.raycastTarget = true;
                alphaColor = transitionImage.color;
                FadeStates = FadeState.FadeInPostProcess;
                break;
            case FadeState.FadeInPostProcess:
                alphaColor.a -= Time.deltaTime;
                transitionImage.color = alphaColor;
                if (transitionImage.color.a <= 0f)
                {
                    transitionImage.raycastTarget = false;
                    FadeStates = FadeState.Invalide;
                }
                break;
            case FadeState.FadeOut:
                transitionImage.raycastTarget = true;
                alphaColor = transitionImage.color;
                FadeStates = FadeState.FadeOutPostProcess;
                break;
            case FadeState.FadeOutPostProcess:
                alphaColor.a += Time.deltaTime;
                transitionImage.color = alphaColor;
                if (transitionImage.color.a >= 1f)
                {
                    transitionImage.raycastTarget = false;
                    FadeStates = FadeState.Invalide;
                }
                break;

        }
    }

}

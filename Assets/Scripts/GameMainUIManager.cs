using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainUIManager : MonoBehaviour
{
    public HPGaugeBase HPGauge;

    public CharacterParameterBase PlayerCharacterParameterBase;

    private Transform playerCharacterTransform;

    private Camera mainCam => Camera.main;

    private Vector3 gaugeOffset = new Vector3(0,1.5f,0);

    private float currentPlayerHPRate;

    private void Start()
    {
        playerCharacterTransform = PlayerCharacterParameterBase.gameObject.transform;
        currentPlayerHPRate = PlayerCharacterParameterBase.GetHPRate;
    }


    // Updateの最後で位置とImageの比率を決定する
    private void LateUpdate()
    {
        // Playerが生きていたら
        if (PlayerCharacterParameterBase.gameObject.activeSelf)
        {
            // ゲージの位置をPlayerの位置に同期する
            HPGauge.transform.position = mainCam.WorldToScreenPoint(playerCharacterTransform.position + gaugeOffset);
       
            // 比率が変更前と違っていたら更新する
            if (currentPlayerHPRate != PlayerCharacterParameterBase.GetHPRate)
            {
                HPGauge.SetGaugeRate(PlayerCharacterParameterBase.GetHPRate);
                currentPlayerHPRate = PlayerCharacterParameterBase.GetHPRate;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainUIManager : MonoBehaviour
{
    public HPGaugeBase HPGauge;

    public CharacterParameterBase PlayerCharacterParameterBase;

    private Transform playerCharacterTransform;

    private Camera mainCam => Camera.main;

    private float currentPlayerHPRate;

    private Vector3 gaugeOffset = new Vector3(0, 1.5f, 0);

    // 敵のCharacterParameter
    public List<CharacterParameterBase> EnemyCharacterParameterBases = new List<CharacterParameterBase>();

    public HPGaugeBase EnemyHPGauge;

    private List<HPGaugeBase> enemyHPGaugeBases = new List<HPGaugeBase>();

    private List<Transform> enemyCharacterTransforms = new List<Transform>();

    private List<float> enemyCurrentHPRates = new List<float>();

    private int enemyCount = 0;

    private void Start()
    {
        playerCharacterTransform = PlayerCharacterParameterBase.gameObject.transform;
        currentPlayerHPRate = PlayerCharacterParameterBase.GetHPRate;

        EnemyCharacterParameterBases.Clear();
        enemyHPGaugeBases.Clear();
        enemyCharacterTransforms.Clear();
        enemyCurrentHPRates.Clear();
    }

    // 敵のゲージの設定
    public void SetEnemiesGaugeSetting(CharacterParameterBase characterParameterBase)
    {
        EnemyCharacterParameterBases.Add(characterParameterBase);
        var gauge = Instantiate(EnemyHPGauge,this.transform);
        enemyHPGaugeBases.Add(gauge.GetComponent<HPGaugeBase>());
        enemyCurrentHPRates.Add(characterParameterBase.GetHPRate);
        gauge.isEnemy = true;
        enemyCount++;
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

        for(int i =0;i< enemyCount;i++)
        {
            enemyHPGaugeBases[i].transform.position = mainCam.WorldToScreenPoint(EnemyCharacterParameterBases[i].transform.position + gaugeOffset);

            if (enemyCurrentHPRates[i] != EnemyCharacterParameterBases[i].GetHPRate)
            {
                enemyHPGaugeBases[i].SetGaugeRate(EnemyCharacterParameterBases[i].GetHPRate);
                enemyCurrentHPRates[i] = EnemyCharacterParameterBases[i].GetHPRate;
            }
        }
    }
}

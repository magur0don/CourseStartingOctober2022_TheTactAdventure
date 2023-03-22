using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGaugeBase : MonoBehaviour
{

    private float maxGaugeRate = 1f;

    private float gaugeRate;

    [SerializeField]
    private Image gaugeImage;

    private void Start()
    {
        // ゲージの初期化
        gaugeImage.fillAmount = maxGaugeRate;
        gaugeRate = maxGaugeRate;
        SetGaugeRate(gaugeRate);
    }

    public void SetGaugeRate(float gaugeRate)
    {
        gaugeImage.fillAmount = gaugeRate / maxGaugeRate;
    }
}

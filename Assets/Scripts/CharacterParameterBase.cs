using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterParameterBase : MonoBehaviour
{
    [SerializeField]
    protected float hitPoint = 2f;

    private float maxHitPoint = 2f;

    public float GetMaxHitPoint
    { 
        get { return maxHitPoint; }
    }

    [SerializeField]
    protected int characterLevel = 1;

    public int GetCharacterLevel
    {
        get { return characterLevel; }
    }

    public bool IsDead = false;

    public UnityAction DamageAction = null;

    /// <summary>
    /// HPの比率を取得する
    /// </summary>
    public float GetHPRate
    { 
        get { return hitPoint / maxHitPoint; }
    }
    
    private void Start()
    {
        maxHitPoint = hitPoint;
    }

    public void Damage(float damage)
    {
        hitPoint -= damage;

        if (hitPoint <= 0f)
        {
            IsDead = true;
            this.gameObject.SetActive(false);
        }
    }

    public void Revival()
    {
        IsDead = false;
        hitPoint = maxHitPoint;
    }

    public void LevelUp(int upperLevel)
    {
        characterLevel += upperLevel;
        // HitPointの上昇
        maxHitPoint += upperLevel;
        hitPoint += upperLevel;
    }

}

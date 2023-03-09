using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParameterBase : MonoBehaviour
{
    [SerializeField]
    protected float hitPoint = 2f;

    private float maxHitPoint = 2f;

    [SerializeField]
    protected int characterLevel = 1;

    public int GetCharacterLevel
    {
        get { return characterLevel; }
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
            this.gameObject.SetActive(false);
        }
    }


    public void LevelUp(int upperLevel)
    {
        characterLevel += upperLevel;

        // HitPointの上昇
        maxHitPoint += upperLevel;
        hitPoint += upperLevel;

    }
}

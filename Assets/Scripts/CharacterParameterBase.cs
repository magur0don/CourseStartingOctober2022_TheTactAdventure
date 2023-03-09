using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParameterBase : MonoBehaviour
{
    [SerializeField]
    protected float hitPoint = 2f;

    public void Damage(float damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0f)
        {
            this.gameObject.SetActive(false);
        }
            
    }

}

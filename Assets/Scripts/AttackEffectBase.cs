using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffectBase : MonoBehaviour
{
    [SerializeField]
    protected float damage = 1f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterParameterBase>())
        {
            var characterParam = collision.gameObject.GetComponent<CharacterParameterBase>();
            characterParam.Damage(damage);

            this.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadArea : MonoBehaviour
{
    private CharacterParameterBase characterParameterBase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out characterParameterBase))
        {
            characterParameterBase.Damage(characterParameterBase.GetMaxHitPoint);
        }
    }
}

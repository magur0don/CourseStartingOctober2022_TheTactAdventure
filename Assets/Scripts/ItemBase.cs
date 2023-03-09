using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    protected delegate void ItemFunctionHandler(CharacterParameterBase characterParameterBase);

    protected ItemFunctionHandler itemFunctionHandler;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // キャラクターが当たってきた時
        if (collision.gameObject.GetComponent<CharacterParameterBase>())
        {
            itemFunctionHandler?.Invoke(collision.gameObject.GetComponent<CharacterParameterBase>());
        }
    }
}

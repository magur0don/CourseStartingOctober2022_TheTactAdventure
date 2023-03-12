using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearPoint : MonoBehaviour
{
    public bool GameClear = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterParameterBase>())
        {
            GameClear = true;
        }
    }

}

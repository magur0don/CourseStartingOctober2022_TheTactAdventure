using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerSearch : MonoBehaviour
{
    public bool IsSearchPlayer = false;

    public float PlayerCharacterDistance = 0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCharacterAnimationController>()) {
            IsSearchPlayer = true;
            var distance = this.transform.position - collision.transform.position;
            PlayerCharacterDistance = distance.x;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCharacterAnimationController>())
        {
            IsSearchPlayer = false;
        }
    }
}

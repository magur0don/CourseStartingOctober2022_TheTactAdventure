using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterAnimationController : CharacterAnimationControllerBase
{

    private SpriteRenderer playerSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // 自分のSpriteRendererを取得
        playerSpriteRenderer = this.GetComponent<SpriteRenderer>();
        SetAnimation(Animation_Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") == 0) {

            SetAnimation(Animation_Idle);
            return;
        }


        if (Input.GetAxis("Horizontal") > 0)
        {
            SetAnimation(Animation_Walk);
            playerSpriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            SetAnimation(Animation_Walk);
            playerSpriteRenderer.flipX = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterAnimationController : CharacterAnimationControllerBase
{

    private SpriteRenderer playerSpriteRenderer;

    private Rigidbody2D playerRigidbody2D;

    private float speedPower = 2.0f;

    private bool isGround = false;

    private float characterUnderPosYDiff = -1.1f;

    // Start is called before the first frame update
    void Start()
    {
        // 自分のSpriteRendererを取得
        playerSpriteRenderer = this.GetComponent<SpriteRenderer>();
        playerRigidbody2D = this.GetComponent<Rigidbody2D>();

        SetAnimation(Animation_Idle);
    }

    private void FixedUpdate()
    {
        var pos = transform.position;
        pos.y += characterUnderPosYDiff;
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.down,1f);
        if (hit.collider != null && hit.collider.tag == "Ground")
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 空中にいる間は何もできない。もしくは降下モーションを出す
        if (!isGround) {
            return;
        }


        if (Input.GetAxis("Horizontal") == 0)
        {
            if (isGround)
            {
                playerRigidbody2D.velocity = Vector2.zero;
            }
            SetAnimation(Animation_Idle);
            return;
        }
        else
        {
            SetAnimation(Animation_Walk);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            playerRigidbody2D.velocity = Vector2.right * speedPower;   
            playerSpriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            playerRigidbody2D.velocity = Vector2.left * speedPower;
            playerSpriteRenderer.flipX = true;
        }
    }
}

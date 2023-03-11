using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterAnimationController : CharacterAnimationControllerBase
{

    private Rigidbody2D enemyRigidbody2D;

    private float speedPower = 1.8f;

    public EnemyPlayerSearch EnemyPlayerSearch;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // 自分のSpriteRendererを取得
        enemyRigidbody2D = this.GetComponent<Rigidbody2D>();

        SetAnimation(Animation_Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (!EnemyPlayerSearch.IsSearchPlayer) {

            SetAnimation(Animation_Idle);
            return;
        }
        if (EnemyPlayerSearch.PlayerCharacterDistance < 0)
        {
            //playerRigidbody2D.velocity = Vector2.right * speedPower;
            SetAnimation(Animation_Attack);
            characterSpriteRenderer.flipX = false;
        }
        else {
            //playerRigidbody2D.velocity = Vector2.left * speedPower;
            SetAnimation(Animation_Attack);
            characterSpriteRenderer.flipX = true;
        }
    }
}

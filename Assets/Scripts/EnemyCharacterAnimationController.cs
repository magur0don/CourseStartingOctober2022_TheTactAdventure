using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterAnimationController : CharacterAnimationControllerBase
{

    private Rigidbody2D enemyRigidbody2D;

    private float speedPower = 1.8f;

    public EnemyPlayerSearch EnemyPlayerSearch;

    [SerializeField]
    private Vector3[] wayPoints = new Vector3[2];

    private enum wayPoint {
        Invalide =-1,
        StartPos,
        EndPos
    }

    private float waitSeconds = 2f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // 自分のSpriteRendererを取得
        enemyRigidbody2D = this.GetComponent<Rigidbody2D>();

        SetAnimation(Animation_Idle);
        for (int i=0;i< wayPoints.Length; i++)
        {
            wayPoints[i] += this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // StartPosまでの移動
        // wayPointを超えたらflipXを変更する
        if (this.transform.position.x < wayPoints[(int)wayPoint.StartPos].x)
        {
            waitSeconds -= Time.deltaTime;

            if (0f > waitSeconds)
            {
                if (characterSpriteRenderer.flipX)
                {
                    characterSpriteRenderer.flipX = false;
                    waitSeconds = 2f;
                }
            }
        }
        else if (this.transform.position.x > wayPoints[(int)wayPoint.EndPos].x)
        {
            waitSeconds -= Time.deltaTime;
            if (0f > waitSeconds)
            {
                if (!characterSpriteRenderer.flipX)
                {
                    characterSpriteRenderer.flipX = true;
                    waitSeconds = 2f;
                }
            }
        }

        // サーチエリアに入らなければ
        if (!EnemyPlayerSearch.IsSearchPlayer)
        {

            if (characterSpriteRenderer.flipX && this.transform.position.x > wayPoints[(int)wayPoint.StartPos].x)
            {
                SetAnimation(Animation_Walk);
                enemyRigidbody2D.velocity = Vector2.left * speedPower;
                return;
            }
            else if (!characterSpriteRenderer.flipX && this.transform.position.x < wayPoints[(int)wayPoint.EndPos].x)
            {
                SetAnimation(Animation_Walk);
                enemyRigidbody2D.velocity = Vector2.right * speedPower;
                return;
            }
            else {
                SetAnimation(Animation_Idle);
                return;
            }
        }


        if (EnemyPlayerSearch.PlayerCharacterDistance < 0)
        {
            SetAnimation(Animation_Attack);
            characterSpriteRenderer.flipX = false;
        }
        else {
            SetAnimation(Animation_Attack);
            characterSpriteRenderer.flipX = true;
        }
    }
}

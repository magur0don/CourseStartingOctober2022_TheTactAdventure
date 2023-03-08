using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationControllerBase : MonoBehaviour
{
    public Animator Animator;

    public const string Animation_Idle = "Idle";
    public const string Animation_Walk = "Walk";
    public const string Animation_Jump = "Jump";
    public const string Animation_Attack = "Attack";

    protected bool isAttackAnimation = false;

    protected void SetAnimation(string animationName)
    {
        //　同じアニメーションだったら帰る
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName(animationName)) {

            return;
        }
        Animator.Play(animationName, 0);

        if (animationName.Equals(Animation_Attack))
        {
            StartCoroutine(StartWaitAnimation());
        }
    }

    IEnumerator StartWaitAnimation()
    {
        isAttackAnimation = true;
        yield return new WaitUntil(()=> Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1);
        isAttackAnimation = false;
    }

}

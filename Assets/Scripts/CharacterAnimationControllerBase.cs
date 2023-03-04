using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationControllerBase : MonoBehaviour
{
    public Animator Animator;

    public const string Animation_Idle = "Idle";
    public const string Animation_Walk = "Walk";

    private bool isGround = false;


    protected void SetAnimation(string animationName)
    {
        //　同じアニメーションだったら帰る
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName(animationName)) {
            return;
        }

        Animator.Play(animationName, 0);
    }
}

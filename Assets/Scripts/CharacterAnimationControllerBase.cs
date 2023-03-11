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

    [SerializeField]
    protected GameObject AttackNoteLow;

    [SerializeField]
    protected GameObject AttackNoteMiddle;

    protected CharacterParameterBase characterParameterBase;

    protected SpriteRenderer characterSpriteRenderer;

    protected virtual void Start()
    {
        characterParameterBase = this.GetComponent<CharacterParameterBase>();
        // 自分のSpriteRendererを取得
        characterSpriteRenderer = this.GetComponent<SpriteRenderer>();
        Debug.Log(characterSpriteRenderer);
    }

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

    public void CreateMisicNote()
    {
        var thisTransform = this.transform;
        var instantiateNote = AttackNoteLow;

        if (characterParameterBase.GetCharacterLevel >= 2)
        {
            instantiateNote = AttackNoteMiddle;
        }

        var note = Instantiate(instantiateNote, thisTransform);

        if (characterSpriteRenderer.flipX)
        {
            note.transform.position += Vector3.left * 2;
            note.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 100);
        }
        else
        {
            note.transform.position += Vector3.right * 2;
            note.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 100);
        }
    }
}

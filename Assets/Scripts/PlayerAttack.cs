using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject FrontAttack;
    [SerializeField] private GameObject UpAttack;
    [SerializeField] private Animator Animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float LimitTime;
    private bool isAttacking = false;
    [SerializeField] private bool Up = false, IsTrigger = false;
    private float delta;
    private void Awake()
    {
        
    }
    private void AttackHandle()
    {
        if (!isAttacking)
        {
            FrontAttack.SetActive(true);
            Animator.SetTrigger("RightAttack");
            if (IsTrigger)
            {
                if (Up)
                {
                    UpAttack.SetActive(true);
                    Animator.SetTrigger("UpAttack");
                }
                else
                {
                    UpAttack.SetActive(true);
                    Animator.SetTrigger("DownAttack");
                }
            }
        }
    }
    private void CheckAnimation()
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("RightAttack"))
        {
            isAttacking = true;
        }
        else if (Animator.GetCurrentAnimatorStateInfo(0).IsName("½Ï ´ë±â¸ð¼Ç_Clip"))
        {
            isAttacking = false;
        }
        else if (Animator.GetCurrentAnimatorStateInfo(0).IsName("UpAttack"))
        {
            isAttacking = true;
        }
    }

    private void Update()
    {
        bool CanTime = false;
        if (Input.GetKeyDown(KeyCode.L))
        {
            AttackHandle();
        }
        CheckAnimation();
        if (isAttacking)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        } else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
         float VAxis = Input.GetAxisRaw("Vertical");
        if (VAxis != 0)
        {
            delta = 0;
            CanTime = true;
            IsTrigger = true;
        }
        
        if (CanTime)
        {
            delta += Time.deltaTime;
            if (delta >= LimitTime)
            {
                delta = 0;
                CanTime = false;
                IsTrigger = false;
                Up = VAxis > 0;
            }
        }
    }
}

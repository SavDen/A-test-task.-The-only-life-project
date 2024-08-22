using UnityEngine;
using System;

[Serializable]
public class AnimController 
{
    public Animator animator;

    public void Move(bool move)
    {
        animator.SetBool("Move", move);
    }

    public void Attack(bool attack)
    {
        animator.SetBool("Attack", attack);
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void Dead()
    {
        animator.SetTrigger("Dead");
    }
}

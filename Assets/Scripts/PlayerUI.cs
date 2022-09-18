using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private Animator anim;
    private bool isDashing,isAttacking,isDeading;
    private float lastAttack;
    private float lastDash;
    private bool isDying;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        AnimationsUpdate();
        CheckAnimation();
    }

    private void AnimationsUpdate()
    {
        anim.SetBool("isDashing", isDashing);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("isDying", isDying);

    }

    private void CheckAnimation()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
            lastAttack = Time.time;
        } 
        if (Time.time > lastAttack + 1)
        {
            isAttacking = false;
        }
       if (Input.GetButtonDown("Dash"))
        {
            isDashing = true;
            lastDash = Time.time;

        }
        if (Time.time > lastDash + 1)
        {
            isDashing = false;

        }
    }
}


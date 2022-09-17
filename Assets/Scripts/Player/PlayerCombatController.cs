using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    private bool combatEnabled;

    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage;

    [SerializeField]
    private Transform attack1HitBoxPos;

    [SerializeField]
    private LayerMask whatIsDamageable;

    private bool gotInput, isAttacking, isFirstAttack,isWalkingWithGun, 
    isArmDestroyed;

    private float lastInputTime = Mathf.NegativeInfinity;

    private float[] attackDetails = new float[2];
    
    private int armCount = 0;
    private GameObject myNewArm; 

    [SerializeField]
    private Transform arm;

    [SerializeField]
    private GameObject aim;


    private Animator anim;
    private PlayerController PC;
    private PlayerStats PS;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
        PC = GetComponent<PlayerController>();
        PS = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        CheckCombatInput();
        CheckAttacks();
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        anim.SetBool("GunAttack", isWalkingWithGun);
    }
    private void CheckCombatInput()
    {

        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButton(1))
        {
            CameraShake.Instance.ShakeCamera(5f, 5f);
            if (combatEnabled)
            {
                // gotInput = true;
                // lastInputTime = Time.time;
            }
        }

       if (!Input.GetMouseButtonDown(0) && Input.GetMouseButton(1))
        {   
            CreateNewArm();
            isWalkingWithGun = true;
            
            armCount ++;
        }
        if (Input.GetMouseButtonUp(1))
        {
            Destroy(myNewArm);
            isWalkingWithGun = false;
            armCount = 0;
        }
    }
    private void CreateNewArm()
    {
        if(armCount < 1)
        {
        myNewArm = Instantiate(aim, arm.transform.position, arm.transform.rotation);
        myNewArm.transform.parent = arm.transform;
        }
    }
    private void CheckAttacks()
    {
        if (gotInput)
        {
            if (!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                isFirstAttack = !isFirstAttack;
                anim.SetBool("attack1", true);
                anim.SetBool("firstAttack", isFirstAttack);
                anim.SetBool("attack1", isAttacking);

            }
        }
        if (Time.time >= lastInputTime + inputTimer)
        {
            gotInput = false;
        }
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPos.position, attack1Radius, whatIsDamageable);

        attackDetails[0] = attack1Damage;
        attackDetails[1] = transform.position.x;

        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("Damage", attackDetails);
            CameraShake.Instance.ShakeCamera(3f, .2f);

        }
    }
    private void FinishAttack1()
    {
        isAttacking = false;
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("attack1", false);
    }
    private void Damage(float[] attackDetails)
    {
        if (!PC.GetDashStatus())
        {
            int direction;
            PS.DecreaseHealt(attackDetails[0]);
            if (attackDetails[1] < transform.position.x)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            PC.Knockback(direction);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);

    }
}

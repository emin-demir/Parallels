using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    public GameUIScript GameUIScript;
    private float maxStamina = 100f;
    private float currentStamina;
    private float staminaCoolDown = 5f;
    private float amount = 20;

    [SerializeField]
    private bool combatEnabled;

    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage;

    [SerializeField]
    private Transform attack1HitBoxPos;

    [SerializeField]
    private LayerMask whatIsDamageable;

    private bool gotInput, isAttacking, isFirstAttack,isWalkingWithGun,isWaitingWithGun;

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
        anim.SetBool("GunIdle", isWaitingWithGun);
        
        if(transform.GetComponent<Rigidbody2D>().velocity.x != 0 )
            {
                isWalkingWithGun = true;
            }
            if(transform.GetComponent<Rigidbody2D>().velocity.x == 0 )
            {
                isWalkingWithGun = false;
            }
    }
    private void CheckCombatInput()
    {
        if ((currentStamina == 0 && Time.time > lastInputTime + staminaCoolDown) || Time.time > lastInputTime + staminaCoolDown)
        {
            GameUIScript.SetMaxStamina(maxStamina);
            currentStamina = maxStamina;
        }
        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButton(1))
        {
            if (combatEnabled && currentStamina >= 0)
            {
                gotInput = true;
                lastInputTime = Time.time;
            }
        }

       if (!Input.GetMouseButtonDown(0) && Input.GetMouseButton(1))
        {   
            isWaitingWithGun = true;
            CreateNewArm();
            
            if(transform.rotation.y == -1 )
            {
                 Transform[] sprites = myNewArm.GetComponentsInChildren<Transform>();
                    
                    sprites[1].position = new Vector3(-0.55f,0.33f,0f) + transform.position;
                    
                    sprites[1].rotation = Quaternion.Euler(sprites[1].rotation.x,180,sprites[1].rotation.z);
                
                // var Sr = myNewArm.GetComponentInChildren<SpriteRenderer>();
                // Sr.flipY = true;
            }
            else{
                Transform[] sprites = myNewArm.GetComponentsInChildren<Transform>();
                    
                    sprites[1].position = new Vector3(0.55f,0.33f,0) + transform.position;
                    sprites[1].rotation = Quaternion.Euler(sprites[1].rotation.x,0,sprites[1].rotation.z);
                    
            }

            armCount ++;
        }
        if (Input.GetMouseButtonUp(1))
        {
            Destroy(myNewArm);
            isWaitingWithGun = false;
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
        currentStamina -= amount;
        GameUIScript.SetStamina(currentStamina);
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

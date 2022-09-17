using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    [SerializeField]
    private Collider2D groundDedectionTrigger;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    private bool IsOnGround;
    private Collider2D[] groundHitDedectionResuts = new Collider2D[16];

    public Transform tr_p;

    public Animator anim;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
    }

    
    void Update()
    {
        UpdateIsOnGround();
        if (IsOnGround == true)
        {
            EnemyFollow();
        }
        
    }

    private void UpdateIsOnGround()
    {
        IsOnGround = groundDedectionTrigger.OverlapCollider(groundContactFilter, groundHitDedectionResuts) > 0;
        
    }

    private void EnemyFollow()
    {
        Vector3 targetposition = new Vector3(tr_p.position.x, gameObject.transform.position.y, tr_p.position.x);
        transform.position = Vector2.MoveTowards(transform.position, targetposition, 3f * Time.deltaTime);

    }




}

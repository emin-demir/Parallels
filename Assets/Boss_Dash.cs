using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Dash : MonoBehaviour
{
    [SerializeField]
    private Collider2D groundDedectionTrigger;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    private bool IsOnGround;
    private Collider2D[] groundHitDedectionResuts = new Collider2D[16];

    public Transform tr;

    public Transform tr_p;

    public Rigidbody2D rb;

    public float lasttime;
    public float cooldown =1f;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIsOnGround();
    }

    private void UpdateIsOnGround()
    {
        IsOnGround = groundDedectionTrigger.OverlapCollider(groundContactFilter, groundHitDedectionResuts) > 0;

        if (IsOnGround == false)
        {
            if (Time.time >= lasttime + cooldown)
            {
                lasttime = Time.time;
                if (tr.position.x < tr_p.position.x)
                {
                    rb.AddForce(new Vector2(5000f, 0f));
                }
                else if (tr.position.x > tr_p.position.x)
                {
                    rb.AddForce( new Vector2(-5000f, 0f));
                }

            }
        }
    }
}

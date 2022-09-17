using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField]
    private Transform tr;
    private Transform tr_p;
    public Rigidbody2D rb;

    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector2 start;
    [SerializeField]
    private Vector2 stop;
    [SerializeField]
    private float oldPosition;

    [SerializeField]
    private Vector2 control;

    [SerializeField]
    private Quaternion rotation;


    [SerializeField]
    private Collider2D groundDedectionTrigger;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    private bool IsOnGround;
    private Collider2D[] groundHitDedectionResuts = new Collider2D[16];

    [SerializeField]
    private int count = 0;


    void Start()
    {
        tr = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        tr_p = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        control = new Vector2(180,0);
    }

    
    void Update()
    {
        focus();
        UpdateIsOnGround();
    }

    private void focus()
    {
        if (IsOnGround == true)
        {
            count++;
        }
        if (count==0)
        {
            EnemyMove();
        }
        else{
            EnemyFollow();
        }
    }

    private void EnemyMove()
    {
        transform.position = Vector2.Lerp(start, stop, Mathf.PingPong(Time.time * speed, 1.0f));
        if (tr.position.x > oldPosition)
        {
            rotation = Quaternion.Euler(0, 180, 0);
            tr.rotation = rotation;
        }
        else if(tr.position.x < oldPosition)
        {
            rotation = Quaternion.Euler(0, 0, 0);
            tr.rotation = rotation;
        }
        oldPosition = transform.position.x;
    }

    private void EnemyFollow()
    {
        Vector3 targetposition = new Vector3(tr_p.position.x,gameObject.transform.position.y,tr_p.position.x);
        transform.position = Vector2.MoveTowards(transform.position, targetposition, 1f*Time.deltaTime);
    }

    private void UpdateIsOnGround()
    {
        IsOnGround = groundDedectionTrigger.OverlapCollider(groundContactFilter, groundHitDedectionResuts) > 0;
    }
}

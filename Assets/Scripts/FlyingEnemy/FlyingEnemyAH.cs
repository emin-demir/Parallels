using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyAH : MonoBehaviour
{
    public float can = 100;
    public BoxCollider2D coll;

    [SerializeField]
    private Collider2D groundDedectionTrigger;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    private bool IsOnGround;
    private Collider2D[] groundHitDedectionResuts = new Collider2D[16];


    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(can);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == coll)
        {
            can = can - 25;
        }

    }

}

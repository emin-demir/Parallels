using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    [SerializeField]
    private Collider2D coll_p;

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private Quaternion a;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        coll_p = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
    }

}

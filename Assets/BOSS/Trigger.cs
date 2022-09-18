using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private float lasttime;
    private float cooldown = 1f;
    private Collider2D PlayerColl;

    public Animator anim;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
        PlayerColl = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lasttime = Time.time;
        // anim.SetTrigger("Fight2");
        

    }
    private void OnTriggerStay2D(Collider2D collusion)
    {

        if (collusion == PlayerColl)
        {
            if (Time.time >= lasttime + cooldown)
            {
                // anim.SetTrigger("Fight2");
            }
        }
        
    }

}

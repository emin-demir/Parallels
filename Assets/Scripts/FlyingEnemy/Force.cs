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

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == coll_p)
        {
            // Player.
        }
    }

}

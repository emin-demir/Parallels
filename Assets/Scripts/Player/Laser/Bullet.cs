using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    private float[] attackDetails = new float[2];


    private float attack1Radius;

    public void start(){

   }
   private void update(){

   }

   private void OnTriggerEnter2D(Collider2D collider)
   {
        attackDetails[0] = 15f;
        attackDetails[1] = transform.position.x;

    collider.transform.parent.SendMessage("Damage", attackDetails);
    Destroy(gameObject);
   }

}


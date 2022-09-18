using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silahscript : MonoBehaviour
{
    public Transform Aim;
    Vector2 direction;

    
    public GameObject bullet;
    public float bulletspeed;
    public Transform shootpoint;


    public float fireRate;
    private float ReadyForNextShoot;

    public Animator gunanimator;

    public PlayerController PC;

    public GameObject Gun;

    public Vector2 silahhareket;
    public GameObject AimGO;
    private SpriteRenderer sr;

    private SpriteRenderer gunSpriteRenderer;

    private SpriteRenderer PCSR;
    private Transform tr;
    public float offset;

    void shoot()
    {
       GameObject BulletIns =  Instantiate(bullet,shootpoint.position, shootpoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * bulletspeed);
        Destroy(BulletIns, 3);
        gunanimator.SetTrigger("Shoot");
    }

    private void Start()
    {
      sr = AimGO.GetComponent<SpriteRenderer>();
      tr = AimGO.GetComponent<Transform>();

      PCSR = PC.GetComponent<SpriteRenderer>();
      gunSpriteRenderer = Gun.GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        Vector2 karakterkonum = PC.transform.position;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Aim.position;
        //gun.transform.right = direction;

        float RotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Aim.transform.rotation = Quaternion.Euler(0f, 0f, RotateZ + offset);
    



        if (RotateZ<89 && RotateZ>-89 || Input.GetKeyDown(KeyCode.A))
        {
            Aim.transform.position = new Vector2(karakterkonum.x , karakterkonum.y + 0.45f);
            sr.flipY = false;
            PCSR.flipX = false;
            gunSpriteRenderer.flipY = false;
        }
        
        else 
        {
            Aim.transform.position = new Vector2(karakterkonum.x , karakterkonum.y + 0.45f);
            sr.flipY = true;
            PCSR.flipX = true;
            gunSpriteRenderer.flipY = true;
        }
        



        //kursun
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time>ReadyForNextShoot)
            {
                ReadyForNextShoot = Time.deltaTime + 1 / fireRate;
                shoot();
            }

        }

    }

}

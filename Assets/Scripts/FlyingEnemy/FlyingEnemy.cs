using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject dilyarasi;

    public Transform SpawnPoint;

    [SerializeField]
    private Collider2D coll;

    [SerializeField]
    private GameObject main;


    private void Start()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == coll)
        {
            SpawnEnemy();
            main.SetActive(false);
        }
    }

    private void SpawnEnemy()
    {
        GameObject diyarasiClone = Instantiate(dilyarasi, SpawnPoint.position, SpawnPoint.rotation);
    }
}

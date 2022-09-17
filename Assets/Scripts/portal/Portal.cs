using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private Collider2D PlayerColl;


    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision == PlayerColl)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

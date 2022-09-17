using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamearauisettings : MonoBehaviour
{
    public GameObject gameinuicanvas;
    public GameObject mainmenucanvas;

    private bool a;
    private bool b;

    void Update()
    {
       a = gameinuicanvas.activeInHierarchy;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (a == true)
            {
                mainmenucanvas.SetActive(true);
                gameinuicanvas.SetActive(false);
                
            }

            else if (a == false)
            {
                gameinuicanvas.SetActive(true);
                mainmenucanvas.SetActive(false);
            }


        }

    }
}

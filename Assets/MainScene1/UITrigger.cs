using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITrigger : MonoBehaviour
{
    public Canvas infoui;
    public Collider2D karakter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == karakter)
        {
            infoui.enabled = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == karakter)
        {
            infoui.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public GameObject inttext;
    public bool inter, toggle;
    public Animator drawer;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            inter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            inter = false;
        }
    }

    private void Update()
    {
        if (inter)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                if (toggle == true)
                {
                    drawer.ResetTrigger("close");
                    drawer.SetTrigger("open");
                }
                if (toggle == false)
                {
                    drawer.ResetTrigger("open");
                    drawer.SetTrigger("close");
                }
                inttext.SetActive(false);
                inter = false;
            }
        }
    }
}

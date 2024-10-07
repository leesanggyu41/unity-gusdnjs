using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightswch : MonoBehaviour
{
    public GameObject inttext, Llight;
    public bool toggle = true, interactable;
    public Renderer lightBulb;
    public Material offlight, onlight;
    public AudioSource lightSwitchSound;
    public Animator anim;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                //lightSwitchSound.Play();
                
            }
        }
        if (toggle == false)
        {
            Llight.SetActive(false);
            lightBulb.material = offlight;
            anim.ResetTrigger("on");
            anim.SetTrigger("off");
        }
        if (toggle == true)
        {
            Llight.SetActive(true);
            lightBulb.material = onlight;
            anim.ResetTrigger("off");
            anim.SetTrigger("on");
        }
    }
}

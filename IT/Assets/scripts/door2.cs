using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class door2 : MonoBehaviour
{
    [SerializeField]

    public problum problum;

    public GameObject intText, HandPoint, cameraa, prob;
    public bool interactable, toggle, boolkey;
    public Animator doorAnim;
    public string Lockname;
    public Text locktext;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    private void Update()
    {
        if (problum.close == true)
        {
            StopCoroutine(Close());
            StartCoroutine(Close());
        }
        if (interactable)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if(problum.close == true && problum.open == false)
                {
                    locktext.text = Lockname;
                    cameraa.tag = "a";
                    intText.SetActive(false);
                    StopCoroutine(disableText());
                    StartCoroutine(disableText());
                    
                }
                else if (problum.open == true && problum.close == false)
                {
                    toggle = !toggle;
                    if (toggle == true)
                    {
                        doorAnim.ResetTrigger("close");
                        doorAnim.SetTrigger("open");
                    }
                    if (toggle == false)
                    {
                        doorAnim.ResetTrigger("open");
                        doorAnim.SetTrigger("close");
                    }
                    intText.SetActive(false);
                    interactable = false;
                }
                else
                {
                    prob.SetActive(true) ;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
   
            }
        }


    }
    IEnumerator disableText()
    {
        yield return new WaitForSeconds(2.0f);
        cameraa.tag = "MainCamera";
        locktext.text = "";
        problum.close = false;
    } 
    IEnumerator Close()
    {
        yield return new WaitForSeconds(3.0f);
        problum.close = false;
    }

}


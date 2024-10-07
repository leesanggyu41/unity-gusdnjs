using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class door : MonoBehaviour
{
    public GameObject intText, HandPoint, cameraa;
    public bool interactable, toggle, boolkey,close;
    public Animator doorAnim;
    public string Keyname, Lockname;
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
        if (boolkey)
        {
            getkeydoor(); 
        }
        else
        {
            nokeydoor();
        }
        
        
    }
    void getkeydoor()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {   if (HandPoint.transform.childCount == 1)
                {
                    if (HandPoint.transform.GetChild(0).name == Keyname)
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
                } if ( HandPoint.transform.childCount <= 0 || HandPoint.transform.GetChild(0).name != Keyname)
                {
                    locktext.text = Lockname;
                    cameraa.tag = "a";
                    intText.SetActive(false);
                    close = true;
                    if (close == true)
                    { 
                        StartCoroutine(disableText());
                    }
                    
                }
            }
        }
        IEnumerator disableText()
        {
            yield return new WaitForSeconds(2.0f);
            close = false;
            cameraa.tag = "MainCamera";
            locktext.text = "";
            
        }
    }
    void nokeydoor()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
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
        }
    }
}


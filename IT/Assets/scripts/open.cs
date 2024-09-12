using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour
{
    public string item_name;
    public GameObject PlayerHandPoint;
    public GameObject inttext, item, usetext;
    public AudioSource pickupSound;
    public bool interactable;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if(PlayerHandPoint.transform.childCount > 0)
            {
                if (PlayerHandPoint.transform.GetChild(0).name == item_name)
                {
                    inttext.SetActive(true);
                    interactable = true;
                }
                else
                {
                    usetext.SetActive(true);
                }
            }
            else
            {
                usetext.SetActive(true);
            }
            
            

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
            usetext.SetActive(false);

        }
    }

    private void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                if (item.CompareTag("Wood"))
                {
                    rb.isKinematic = false;
                }
            }
        }
    }
}

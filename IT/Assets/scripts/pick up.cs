using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Text itemname;
    public GameObject PlayerHandPoint;
    public GameObject inttext, item;
    public AudioSource pickupSound;
    public bool interactable;
    public bool isPickup = false;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;

        }
    }
    private void Update()
    {
        Updateitemname();
        if (PlayerHandPoint.transform.childCount == 0)
        {
            if (interactable == true)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                    inttext.SetActive(false);
                isPickup = true;
                transform.SetParent(PlayerHandPoint.transform);
                transform.localPosition = Vector3.zero;
                rb.isKinematic = true;
            }
        }
        }
        

        if (isPickup == true)
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                isPickup = false;
                transform.SetParent(null);
                rb.isKinematic = false;
            }
        }
    }

    void Updateitemname()
    {
        if (PlayerHandPoint.transform.childCount > 0)
        {
            itemname.text = PlayerHandPoint.transform.GetChild(0).name;
        }
        else
        {
            itemname.text = "";
        }
    }
}

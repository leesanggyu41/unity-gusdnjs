using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class handlight : MonoBehaviour
{
    public Text itemname;
    public GameObject PlayerHandPoint;
    public GameObject inttext, Handlight,player;
    public AudioSource pickupSound, toggleSound;
    public bool interactable, toggle;
    public bool isPickup = false;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (toggle == false)
        {
            Handlight.SetActive(false);
        }
        if (toggle == true)
        {
            Handlight.SetActive(true);
        }
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
        if (PlayerHandPoint.transform.childCount == 0)        {
            if (interactable == true)
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    inttext.SetActive(false);
                    isPickup = true;
                    transform.SetParent(PlayerHandPoint.transform, false);
                    transform.localPosition = Vector3.zero;
                    transform.localRotation = Quaternion.Euler(0, 0, 0);

                    rb.isKinematic = true;
                }
            }
        }


        if (isPickup == true)
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                isPickup = false;
                rb.isKinematic = false;

                // 부모에서 분리
                transform.SetParent(null, false);

                // 핸드 바로 아래에서 떨어뜨리기
                Vector3 dropPosition = PlayerHandPoint.transform.position + Vector3.down * 0.5f; // 핸드 위치에서 아래로 이동
                transform.position = dropPosition; // 위치 설정
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                toggle = !toggle;
                //toggleSound.Play();
                if (toggle == false)
                {
                    Handlight.SetActive(false);
                }
                if (toggle == true)
                {
                    Handlight.SetActive(true);
                }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Text itemname;
    public GameObject PlayerHandPoint, player;
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

            if (PlayerHandPoint.transform.childCount == 0 && interactable)
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    inttext.SetActive(false);
                    isPickup = true;
                    transform.SetParent(PlayerHandPoint.transform, false);
                    transform.localPosition = Vector3.zero; // 핸드 위치
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    rb.isKinematic = true;
                }
            }

            if (isPickup)
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


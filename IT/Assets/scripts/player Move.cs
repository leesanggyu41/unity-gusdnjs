using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    public Image runningBar;
    public bool enBar = true;
    public float walkingSpeed = 5.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    private float saveWalk;
    private float saveRun;
    private float saveJump;
    public float SitJump = 5.0f;
    public float SitSpeed = 4.5f;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public bool tidrb = false;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        saveWalk = walkingSpeed;
        saveRun = runningSpeed;
        saveJump = jumpSpeed;
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            tidrb = !tidrb;
            sitOn();


        }
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning;
        if (enBar == true)
        {
            isRunning = Input.GetKey(KeyCode.LeftShift);
        }
        else
        {
            isRunning = false;
        }
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxisRaw("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxisRaw("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        if (Input.GetKey(KeyCode.LeftShift) && enBar && !tidrb)
        {
            if (runningBar.transform.localScale.x >= 0)
            {
                runningBar.transform.localScale += new Vector3(-0.007f, 0f, 0f);
                if (runningBar.transform.localScale.x <= 0 && enBar)
                {
                    runningBar.color = Color.red;
                    enBar = false;
                }
            }

        }
        else
        {
            if (runningBar.transform.localScale.x <= 1 && enBar)
            {
                runningBar.transform.localScale += new Vector3(0.003f, 0f, 0f);

            }
            else if (runningBar.transform.localScale.x <= 1 && !enBar)
            {
                runningBar.transform.localScale += new Vector3(0.001f, 0f, 0f);
                if (runningBar.transform.localScale.x >= 1)
                {
                    runningBar.color = Color.white;
                    enBar = true;
                }



            }

        }

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }


        characterController.Move(moveDirection * Time.deltaTime);


        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

    }
    public void sitOn()
    {
        if (tidrb == true)
        {
            transform.localScale = new Vector3(1f, 0.5f, 1f);
            walkingSpeed = SitSpeed;
            runningSpeed = SitSpeed;
            jumpSpeed = SitJump;
        }
        else if (tidrb == false)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            walkingSpeed = saveWalk;
            runningSpeed = saveRun;
            jumpSpeed = saveJump;
        }

    }
}
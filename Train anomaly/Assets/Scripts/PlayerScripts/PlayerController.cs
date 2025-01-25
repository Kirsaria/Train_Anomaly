using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed;
    private CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        if (Time.timeScale == 1)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
            moveDirection.y -= 9.81f * Time.deltaTime;
            characterController.Move(moveDirection * movespeed * Time.deltaTime);
        }
    }
}

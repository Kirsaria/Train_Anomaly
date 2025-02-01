using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed;
    public AudioSource footstepAudio; // ������ �� AudioSource
    public AudioClip footstepSound;   // ���� �����

    private CharacterController characterController;
    private bool isMoving; // ���� ��� ������������ ��������

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // ��������� ���� �����
        if (footstepAudio != null)
        {
            footstepAudio.clip = footstepSound;
            footstepAudio.loop = true; // ���� ����� �����������
        }
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            bool wasMoving = isMoving;
            isMoving = Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f;

            if (isMoving && !wasMoving)
            {
                PlayFootstepSound();
            }
            else if (!isMoving && wasMoving)
            {
                StopFootstepSound();
            }

            Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
            moveDirection.y -= 9.81f * Time.deltaTime;
            characterController.Move(moveDirection * movespeed * Time.deltaTime);
        }
        else
        {
            StopFootstepSound();
        }
    }
    private void PlayFootstepSound()
    {
        if (footstepAudio != null && !footstepAudio.isPlaying)
        {
            footstepAudio.Play();
        }
    }
    private void StopFootstepSound()
    {
        if (footstepAudio != null && footstepAudio.isPlaying)
        {
            footstepAudio.Stop();
        }
    }
}
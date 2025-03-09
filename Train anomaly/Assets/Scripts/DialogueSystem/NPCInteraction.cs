using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private DialogeStory dialogeStory;
    [SerializeField] private string startTag = "Приветственный"; 

    private bool isPlayerInTrigger = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 1;
            isPlayerInTrigger = false; 
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false; 
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            dialogeStory.gameObject.SetActive(true);
            dialogeStory.ChangeStory(startTag);
        }
    }
}
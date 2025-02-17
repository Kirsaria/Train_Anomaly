using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer_trigger : MonoBehaviour
{
    public GameObject scream;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scream.SetActive(true);
        }
    }
}

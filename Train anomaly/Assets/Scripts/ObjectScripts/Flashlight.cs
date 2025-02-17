using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject spotlight;
    private bool isFlashlightOn = false;
    public bool grabActive = false;
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && grabActive)
        {
            isFlashlightOn = !isFlashlightOn;
        }
        if(isFlashlightOn)
        {
            spotlight.SetActive(true);
        }
        else
        {
            spotlight.SetActive(false);
        }
    }
}

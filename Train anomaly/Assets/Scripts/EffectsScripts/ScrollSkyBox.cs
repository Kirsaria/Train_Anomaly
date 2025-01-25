using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSkyBox : MonoBehaviour
{
    public float rotationSpeed = 2.0f;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}

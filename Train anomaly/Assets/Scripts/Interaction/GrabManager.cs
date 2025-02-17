using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class GrabManager : MonoBehaviour
{
    public float interactionDistance = 3.0f;
    public GameObject lightPoint;
    public LayerMask mask;
    private Camera camera;
    void Start()
    {
        camera = Camera.main;
    }
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, interactionDistance, mask))
        {
            Flashlight flashlight = hit.collider.GetComponent<Flashlight>();
            if(flashlight != null && !flashlight.grabActive)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    flashlight.transform.parent = lightPoint.transform;
                    flashlight.transform.localPosition = Vector3.zero;
                    flashlight.transform.localEulerAngles = Vector3.zero;
                    flashlight.grabActive = true;
                    Debug.Log("GrabLight");
                }
            }
        }
    }
}

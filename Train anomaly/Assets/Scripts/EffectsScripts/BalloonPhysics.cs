using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPhysics : MonoBehaviour
{
    public float liftForce = 10f; // Сила подъема
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Применяем силу вверх
        rb.AddForce(Vector3.up * liftForce, ForceMode.Force);
        Vector3 randomForce = new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(-0.1f, 0.1f));
        rb.AddForce(randomForce, ForceMode.Impulse);
    }
}

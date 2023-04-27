using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour
{
    private Transform wheelTransform;
    Rigidbody draggingObject;

    float wheelRadius = 0.014f;

    void Start()
    {
        wheelTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        draggingObject = GetComponentInParent<Rigidbody>();
        // draggingObject.contact

        if (draggingObject != null)
    {
        float rotationSpeed = draggingObject.velocity.magnitude / 2f / Mathf.PI * 360 * Time.deltaTime / wheelRadius;
        wheelTransform.Rotate(Vector3.up, rotationSpeed);
    }
    }

    public void StartRotating()
    {
    enabled = true;
    }
}

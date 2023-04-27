using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndRelease : MonoBehaviour
{

    private Vector3 offset;

    public bool inputActive = false;

    public GameObject Thumb;
    public GameObject Index;

    Rigidbody draggingObject;

    Vector3 startPosition;

    void OnTriggerStay(Collider other) {

        if (!draggingObject && inputActive && other.attachedRigidbody) {
            draggingObject = other.attachedRigidbody; 
            startPosition = draggingObject.transform.position;
            draggingObject.isKinematic = true;
            
            print(draggingObject);
        }
    }

    void Update() {
    inputActive = Vector3.Distance(Thumb.transform.position, Index.transform.position) < 0.03f;

        if (draggingObject != null)
        {
            Vector3 surfacePosition = transform.position;
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit)) {
                float high = draggingObject.GetComponentInChildren<BoxCollider>().bounds.extents.y * draggingObject.transform.localScale.y;
                surfacePosition = hit.point + high * hit.normal;
            }

            if (!inputActive) {
                draggingObject.isKinematic = false;
                draggingObject.velocity = (startPosition - draggingObject.transform.position).normalized * 2f;

                // WheelCollider[] wheels = draggingObject.GetComponentsInChildren<WheelCollider>();
                // foreach (WheelCollider wheel in wheels)
                // {
                //     wheel.gameObject.GetComponent<RotateWheels>().StartRotating();
                // }

                draggingObject = null;
            } else {
                draggingObject.transform.position = surfacePosition;
            }
        }
    }
}

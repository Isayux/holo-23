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

    void OnTriggerStay(Collider other)
    {



        if (!draggingObject && inputActive && other.attachedRigidbody) {
            draggingObject = other.attachedRigidbody; 
            startPosition = draggingObject.transform.position;
            draggingObject.isKinematic = true;
            
            print(draggingObject);
        }
    }

    void Update()
    {

        inputActive = Vector3.Distance(Thumb.transform.position, Index.transform.position) < 0.05f;

        if(draggingObject != null) {
            
            Vector3 surfacePositon = transform.position;
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit)) {

                float high = draggingObject.GetComponent<BoxCollider>().size.y / 2 * draggingObject.transform.localScale.y;
                surfacePositon = hit.point + high * hit.normal;
            };
            
            if (!inputActive) {
            draggingObject.isKinematic = false;

            draggingObject.velocity = (startPosition - draggingObject.transform.position).normalized * 10f;
            
            draggingObject = null;  
        } else {

            draggingObject.transform.position = surfacePositon;
        }
        }


        // Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        // Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        // curPosition.y = transform.position.y; // Garde la position Y inchangée
        // curPosition.z = transform.position.z; // Garde la position Z inchangée
        // transform.position = curPosition;
    }

    public void StopDrag()
    {
        // Vector3 mouseDelta = Input.mousePosition - screenPoint;
        // float forceMultiplier = Mathf.Clamp(mouseDelta.magnitude / 10f, 0f, 10f);
        // Vector3 force = mouseDelta.normalized * forceMultiplier;
        
        // if (force.x < 0f) {
        //     force.x *= -1f;
        // } else if (force.x > 0f) { // Vérifie si la force est dirigée vers la droite (sens positif)
        //     force.x *= -1f; // Inverse la direction de la force
        // }
        
        // rb.AddForce(force, ForceMode.Impulse);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    // Start is called before the first frame update
    public float lastPosition; // dernière position du parent
    public float rotationSpeed; // vitesse de rotation des enfants
    public bool wheelsRotating = false; // booléen pour savoir si les roues tournent
    public Transform[] transformsToRotate;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        transformsToRotate = GetComponentsInChildren<Transform>();
        lastPosition = transform.position.x; // initialisation de la dernière position

    }

    void rotateWheels (){
        if(wheelsRotating ){

        float distance = rb.velocity.x * Time.fixedDeltaTime;
        rotationSpeed = distance * 6000f;

        for (int i = 1; i < transformsToRotate.Length; i++)
        {
            transformsToRotate[i].Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
        }
    }

    void Update()
    {
        rotateWheels();
    }
}

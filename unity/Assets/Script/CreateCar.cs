using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCar : MonoBehaviour
{
    public bool inputActiveLeft = false;
    public GameObject Thumb;
    public GameObject Index;
    public GameObject[] carPrefabs;
    private bool carCreated = false;
    private Rigidbody[] carRigidbodies; // Reference to the Rigidbody component of the car
    private int carCounter = 0;
    private int maxCars = 15;

    void Start()
    {
        carRigidbodies = new Rigidbody[maxCars];
    }

    void Update()
    {
        inputActiveLeft = Vector3.Distance(Thumb.transform.position, Index.transform.position) < 0.05f;

        if (inputActiveLeft && !carCreated && carCounter < maxCars) {
            Vector3 newObjectPosition = (Thumb.transform.position + Index.transform.position) / 2f;
            int randomIndex = Random.Range(0, carPrefabs.Length);
            GameObject newObject = Instantiate(carPrefabs[randomIndex], newObjectPosition, Quaternion.identity);
            Rigidbody newRigidbody = newObject.GetComponent<Rigidbody>(); // Get the reference to the Rigidbody component
            carRigidbodies[carCounter] = newRigidbody;
            carCounter++;
            carCreated = true;
        } else if (!inputActiveLeft && carCreated) {
            carRigidbodies[carCounter - 1].isKinematic = false; // Allow the car to be affected by gravity
            carCreated = false;
        }

        if (carCreated) {
            Vector3 newObjectPosition = (Thumb.transform.position + Index.transform.position) / 2f;
            carRigidbodies[carCounter - 1].transform.position = newObjectPosition; // Set the position of the car to the position of the hand
        }

        if (carCounter >= maxCars) {
            Destroy(carRigidbodies[0].gameObject);
            for (int i = 1; i < carCounter; i++) {
                carRigidbodies[i - 1] = carRigidbodies[i];
            }
            carCounter--;
        }
    }
}

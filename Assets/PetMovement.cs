using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject pet;
    private float yOffset = 0f;
    private Vector3 petPosition = new Vector3(0, 0, 0);
    // Update is called once per frame
    void Update()
    {
        // check for up and down movement
        Vector3 inputDir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.Q)) {
            yOffset -= 1f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E)) {
            yOffset += 1f * Time.deltaTime;
        }

        // sync pet position with player
        Vector3 playerPosition = transform.position;
        petPosition.x = playerPosition.x - 0.7f;
        petPosition.y = playerPosition.y + 2.12f + yOffset;
        petPosition.z = playerPosition.z - 2.9f;

        pet.transform.position = petPosition;


    }
}

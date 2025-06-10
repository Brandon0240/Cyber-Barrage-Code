using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetRotationOnObject : MonoBehaviour
{
    private Transform player; // Reference to the player's Transform
    public Transform rotatedPoint; // The object that will rotate (e.g., a weapon)
    private float rotationSpeed = 1000f; // Speed at which the object rotates to face the player
   
    void Start()
    {
       
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player 1");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player GameObject is tagged as 'Player 1'.");
        }

        if (rotatedPoint == null)
        {
            Debug.LogError("rotatedPoint is not assigned! Assign it in the Inspector.");
        }
    }

    void Update()
    {
        if (player != null && rotatedPoint != null)
        {
            RotateAroundPoint3();
            
        }
    }
    private bool isFlipped = false;
    void RotateAroundPoint3()
    {

        Vector3 direction = player.position - rotatedPoint.position;

 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
   

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


        bool shouldFlip = (angle > 90 || angle < -90);

        if (shouldFlip && !isFlipped)
        {
            transform.localScale = new Vector3(transform.localScale.x * 1, transform.localScale.y * -1, transform.localScale.z);
            isFlipped = true;
        }
        else if (!shouldFlip && isFlipped)
        {
            transform.localScale = new Vector3(transform.localScale.x * 1, transform.localScale.y * -1, transform.localScale.z);
            isFlipped = false;
        }


        float radius = Vector3.Distance(transform.position, rotatedPoint.position);
        Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * radius;
        transform.position = rotatedPoint.position + offset;
    }


    
}

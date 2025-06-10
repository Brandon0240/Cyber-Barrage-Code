using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour
{
    private Transform player; 
    public float rotationSpeed = 5f;
    void Start()
    {

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player 1");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Transform>();
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player GameObject is tagged as 'Player'.");
        }
    }

    void Update()
    {
        Rotate();
    }
    public void Rotate()
    {
        if (player != null)
        {

            Vector3 direction = player.position - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


            Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
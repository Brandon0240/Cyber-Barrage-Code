using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer1Tag : MonoBehaviour
{
    private GameObject playerObject;
    void Start()
    {

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player 1");
        if (playerObject != null)
        {
            
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player GameObject is tagged as 'Player'.");
        }
    }

    public GameObject findPlayer1()
    {
        return playerObject;
    }
}

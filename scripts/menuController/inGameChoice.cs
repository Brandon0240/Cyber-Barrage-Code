using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameChoice : MonoBehaviour
{
    public GameObject choiceHolder;
    public GameObject character1;
    public GameObject character2;
    public Transform spawnPoint;



    public int choice = 0;


    void Start()
    {
      //  choice = choiceHolder.getChoiceOne();
        spawn();
    }


    void Update()
    {
        
    }
    void spawn()
    {
        if (choice == 1)
        {
           // Instantiate(character1, spawnPoint.position, spawnPoint.rotation);
            //character1.GetComponent.Player.changePlayerId(1);//finish this
        }
    }
}

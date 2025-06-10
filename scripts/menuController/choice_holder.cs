using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choice_holder : MonoBehaviour
{
    public int oneChoice = 0;
    public int secChoice = 0;

    public GameObject PvpChoice;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
       // oneChoice = PvpChoice.getPlayer1();
        //secChoice = PvpChoice.getPlayer2();

    }
    public int getChoiceOne()
    {
        return oneChoice;
    }
    public int getChoiceTwo()
    {
        return secChoice;
    }
}

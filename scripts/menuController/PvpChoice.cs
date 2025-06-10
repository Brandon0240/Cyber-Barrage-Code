using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PvpChoice : MonoBehaviour
{

    public int player1 = 0;
    public int player2 = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
   
    
    public void Begin()
    {
        if(player1 == 1 && player2 == 1)
        {
            // SceneManager.LoadScene("pvp");
        }
        if (player1 == 1 && player2 == 2)
        {
            // SceneManager.LoadScene("pvp");
        }
        if (player1 == 2 && player2 == 1)
        {
            // SceneManager.LoadScene("pvp");
        }
        if (player1 == 2 && player2 == 2)
        {
            // SceneManager.LoadScene("pvp");
        }
    }
    public void p1Choice1()
    {
        player1 = 1;
     }
    public void p1Choice2()
    {
        player1 = 2;
    }


    public void Lock2()
    {

    }
    public void p2Choice1()
    {
        player2 = 1;
    }
    public void p2Choice2()
    {
        player2 = 2;
    }
    public void StartGame()
    {
        if(player1 != 0 && player2 != 0)
        {
            SceneManager.LoadScene("test");
        }
        
    }
    public void GoMenu()
    {
        
        SceneManager.LoadScene("Menu");
    }
    public int getPlayer1()
    {
        return player1;
    }
    public int getPlayer2()
    {
        
        return player2;
    }

}

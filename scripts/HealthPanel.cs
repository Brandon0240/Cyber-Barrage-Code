using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    public Text livesText;
    public int lives;
    public Player myplayer;
    void Start()
    {
        livesText.text = lives.ToString();

    }



    public void LoseLife()
    {
        lives = lives - 2;
        livesText.text = lives.ToString();

        Destroyed();
	}
    public void PvpLoseLife(int dps)
    {
        lives = lives - dps;
        livesText.text = lives.ToString();
        Destroyed();
    }
    public void GainLife()
    {
        lives = lives + 1;
        livesText.text = lives.ToString();
    }
    
    public void LoseLessLife()
    {
        lives = lives - 1;
        livesText.text = lives.ToString();

        Destroyed();
    }
    public void Death()
    {
        lives = lives - 3;
        livesText.text = lives.ToString();
        Destroyed();

    }
    public void Destroyed()
    {
        if (lives <= 0)
        {
            Destroy(myplayer.gameObject);
        }
    }

}

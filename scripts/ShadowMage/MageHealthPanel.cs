using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MageHealthPanel : MonoBehaviour
{
    public Text livesText;
    public int lives= 10;
    public test myplayer;
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PvpLoseLife(int dps)
    {
        lives = lives - dps;
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
    public void Death()
    {
        lives = lives - lives;
        livesText.text = lives.ToString();
        Destroyed();

    }
}

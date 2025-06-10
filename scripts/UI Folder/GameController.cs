using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public Pause Pause;
    private bool isPaused = false;
    int points = 0;
    public Text pointsText;

    public UltimateController UltimateController;
    public void GameOver()
    {
        
        GameOverScreen.Setup(points);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            UnityEngine.Debug.Log("F");
            if (!isPaused)
            {
                Pause.Paused();
            }
            else
            if (isPaused)
            {
                Pause.Resume();
            }
        }

        //timePoints();

        pointsText.text = "Score: " + points.ToString();
    }
    public void timePoints()
    {
        int t = Mathf.RoundToInt(1+ Time.deltaTime);
        points = points + t;
        
    }
    public void addPoints(int amount)
    {
        points += amount;
        UltimateController.GainUltimateCharge();
    }
}

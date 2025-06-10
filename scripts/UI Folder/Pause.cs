using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.F))
        {
            UnityEngine.Debug.Log("F");
            if (!isPaused)
            {
                Paused();
            } else 
            if (isPaused)
            {
                Resume();
            }
        }
        */
    }
    public void Paused()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restart()
    {

        SceneManager.LoadScene("pvetest1");
        Time.timeScale = 1f;
    }
    public void Home()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}

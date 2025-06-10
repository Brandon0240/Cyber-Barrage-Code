using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score)
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }
    public void RestartButton()
    {
        if (Time.timeScale == 0f)
        {
            Debug.Log("TimeScale was 0, resetting it before restarting...");
            Time.timeScale = 1f;
        }

        SceneManager.LoadScene("pvetest1");
        //SceneManager.LoadSceneAsync("pvetest1");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
}


 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menuController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text waveText;
    void Start()
    {
        highestWaveLoad();
    }

    // Update is called once per frame
    void Update()
    {
        highestWaveLoad();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("pvetest1");
    }
    public void QuitGame()
    {

        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;

        }
        else
        {
            Application.Quit();
        }

    }
    void highestWaveLoad()
    {
        SaveData loadedData = SaveSystem.Load();
        if (loadedData != null)
        {
            int highestWave = loadedData.highestWave; 
            waveText.text = "Highest Wave: " + highestWave.ToString();
        }
        else
        {
            waveText.text = "Highest Wave: No save data found. ";
        }
    }
    
    public void GoMenu()
    {
      //  SceneManager.LoadScene("Mainmenu");
    }

}
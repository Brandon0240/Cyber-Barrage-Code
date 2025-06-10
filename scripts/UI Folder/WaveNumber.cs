using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveNumber : MonoBehaviour
{
    public Text waveText;
    public Text EndScreenWaveText;
    private int wave = 0;
    private int savedHighestWave = 0;
    void Start()
    {

    }
    void Update()
    {


        waveText.text = "Wave: " + wave.ToString();
        EndScreenWaveText.text = "Completed " + (wave - 1).ToString()+" Waves";
    }
    public void IncrementWaveNum()
    {
        wave++;
        saveWavedata();
    }
    public int getWaveNum()
    {
        return wave;
    }
    private void saveWavedata()
    {
        if (wave > savedHighestWave)
        {
            SaveData data = new SaveData
            {
                highestWave = wave - 1,
                playerName = "Player1"
            };
            SaveSystem.Save(data);
        }
    }
    void waveSavedLoad()
    {
        SaveData loadedData = SaveSystem.Load();
        if (loadedData != null)
        {
            savedHighestWave = loadedData.highestWave; 
        }
        else
        {
            savedHighestWave = 0;
        }
    }

}

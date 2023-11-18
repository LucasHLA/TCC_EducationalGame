using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PosGameController : MonoBehaviour
{
    public bool posGameActive;
    public bool posGameEffects;
    public bool afterPosGame;
    public bool startChronometer;

    [Header("Time Variables")]
    public string springTime;
    public string summerTime;
    public string autumnTime;
    public string winterTime;
    public string finalTime;

    public float accumulatedTime;

    [Header("Total Final Time")]
    public float totalTime1;
    public float totalTime2;
    public float totalTime3;
    public float totalTime4;
    public float totalGeneralTime;

    private PosGameController instance;

    [Header("Gallery Related")]
    public bool unlockSpring;
    public bool unlockSummer;
    public bool unlockAutumn;
    public bool unlockWinter;
    public bool unlockCientist;
    public bool unlockSeasons;
    public bool unlockRobots;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        AcumulateTime();
        FinalTime();
        ActivatePosGame();

        if (posGameEffects)
        {
           UnlockGalleryImages();
        }
        else
        {
            return;
        }
    }

    public void AcumulateTime()
    {  
        int minutes = Mathf.FloorToInt(accumulatedTime / 60f);
        int seconds = Mathf.FloorToInt(accumulatedTime % 60f);
        int milliseconds = Mathf.FloorToInt((accumulatedTime * 1000) % 1000);
        string formattedTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        switch (SceneManager.GetActiveScene().name)
        {
            case "Primavera":
                springTime = formattedTime;
                totalTime1 = accumulatedTime;
                break;
            case "Verao":
                summerTime = formattedTime;
                totalTime2 = accumulatedTime;
                break;
            case "Outono":
                autumnTime = formattedTime;
                totalTime3 = accumulatedTime;
                break;
            case "Inverno":
                winterTime = formattedTime;
                totalTime4 = accumulatedTime;
                break;
        }
    }

    public void FinalTime()
    {
        totalGeneralTime = totalTime1 + totalTime2 + totalTime3 + totalTime4;

        int minutes = Mathf.FloorToInt(totalGeneralTime / 60f);
        int seconds = Mathf.FloorToInt(totalGeneralTime % 60f);
        int milliseconds = Mathf.FloorToInt((totalGeneralTime * 1000) % 1000);
        string finalFormattedTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        finalTime = finalFormattedTime;

    }

    void ActivatePosGame()
    {
        if(SceneManager.GetActiveScene().name == "Final")
        {
            posGameActive = true;
        }
        else
        {
            return;
        }

        if(SceneManager.GetActiveScene().name == "PosGameFinal")
        {
            afterPosGame = true;
            posGameEffects = false;
        }
        else
        {
            return;
        }


    }

    public void UnlockGalleryImages()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "infoPrim":
                unlockSpring = true;
                break;

            case "infoVerao":
                unlockSummer = true;
                break;

            case "infoOuto":
                unlockAutumn = true;
                break;

            case "infoInver":
                unlockWinter = true;
                break;
        }
    }
}

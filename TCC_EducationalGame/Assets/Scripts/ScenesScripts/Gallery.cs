using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gallery : MonoBehaviour
{
    [Header("Image padlocks array")]
    public GameObject[] imageLocks;

    [Header("Images")]
    public string imageName;
    public bool unlockSpring;
    public bool unlockSummer;
    public bool unlockAutumn;
    public bool unlockWinter;
    public bool unlockSeasons;
    public bool unlockCientist;
    public bool unlockBoss;
    public bool unlockRobots;


    private Gallery instance;
    void Start()
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
        UnlockImages();
    }

    void UnlockImages()
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

        if(SceneManager.GetActiveScene().name == "Menu")
        {
            if (unlockSpring)
            {
                imageLocks[0].SetActive(false);
            }
            if (unlockSummer)
            {
                imageLocks[1].SetActive(false);
            }
            if (unlockAutumn)
            {
                imageLocks[2].SetActive(false);
            }
            if (unlockWinter)
            {
                imageLocks[3].SetActive(false);
            }
            if (unlockCientist)
            {
                imageLocks[4].SetActive(false);
            }
            if (unlockBoss)
            {
                imageLocks[5].SetActive(false);
            }
            if (unlockSeasons)
            {
                imageLocks[6].SetActive(false);
            }
            if (unlockRobots)
            {
                imageLocks[7].SetActive(false);
            }
        }
    }
}

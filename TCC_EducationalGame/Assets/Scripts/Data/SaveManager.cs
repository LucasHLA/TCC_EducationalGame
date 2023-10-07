using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private SaveManager instance;

    [Header("Gallery variables to save")]

    public bool springGallery;
    public bool summerGallery;
    public bool autumnGallery;
    public bool winterGallery;
    public bool cientistGallery;
    public bool seasonsGallery;
    public bool robotsGallery;
    public bool posGameActive;

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

        posGameActive = GameObject.FindObjectOfType<PosGameController>().posGameActive;
        springGallery = GameObject.FindObjectOfType<PosGameController>().unlockSpring;
        summerGallery = GameObject.FindObjectOfType<PosGameController>().unlockSummer;
        autumnGallery = GameObject.FindObjectOfType<PosGameController>().unlockAutumn;
        winterGallery = GameObject.FindObjectOfType<PosGameController>().unlockWinter;
        cientistGallery = GameObject.FindObjectOfType<PosGameController>().unlockCientist;
        seasonsGallery = GameObject.FindObjectOfType<PosGameController>().unlockSeasons;
        robotsGallery = GameObject.FindObjectOfType<PosGameController>().unlockRobots;
    }

    public void SaveGame()
    {
      
        PlayerPrefs.SetInt("PosGameActive", posGameActive ? 1 : 0);
        PlayerPrefs.SetInt("SpringGallery", springGallery ? 1 : 0);
        PlayerPrefs.SetInt("SummerGallery", summerGallery ? 1 : 0);
        PlayerPrefs.SetInt("AutumnGallery", autumnGallery ? 1 : 0);
        PlayerPrefs.SetInt("WinterGallery", winterGallery ? 1 : 0);
        PlayerPrefs.SetInt("CientistGallery", cientistGallery ? 1 : 0);
        PlayerPrefs.SetInt("SeasonGallery", seasonsGallery ? 1 : 0);
        PlayerPrefs.SetInt("RobotsGallery", robotsGallery ? 1 : 0);
        Debug.Log("Save");
    }

    public void LoadGame()
    {

        GameObject.FindObjectOfType<PosGameController>().posGameActive = PlayerPrefs.GetInt("PosGameActive") == 1;
        GameObject.FindObjectOfType<PosGameController>().unlockSpring = PlayerPrefs.GetInt("SpringGallery") == 1;
        GameObject.FindObjectOfType<PosGameController>().unlockSummer = PlayerPrefs.GetInt("SummerGallery") == 1;
        GameObject.FindObjectOfType<PosGameController>().unlockAutumn = PlayerPrefs.GetInt("AutumnGallery") == 1;
        GameObject.FindObjectOfType<PosGameController>().unlockWinter = PlayerPrefs.GetInt("WinterGallery") == 1;
        GameObject.FindObjectOfType<PosGameController>().unlockCientist = PlayerPrefs.GetInt("CientistGallery") == 1;
        GameObject.FindObjectOfType<PosGameController>().unlockSeasons = PlayerPrefs.GetInt("SeasonsGallery") == 1;
        GameObject.FindObjectOfType<PosGameController>().unlockRobots = PlayerPrefs.GetInt("RobotsGallery") == 1;
        Debug.Log("Load");
    }
}

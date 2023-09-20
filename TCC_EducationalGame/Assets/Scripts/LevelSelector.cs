using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [Header("Levels")]
    public bool spring;
    public bool summer;
    public bool autumn;
    public bool winter;

    private static LevelSelector instance;
    
    void Awake()
    {
        if(instance != null)
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
        Levels();
        RestartLevels();
    }

    void Levels()
    {
        bool isTeleportActive = GameObject.FindGameObjectWithTag("Teleport") != null;
        if(isTeleportActive ==  true)
        {
            if (!spring && !summer && !autumn && !winter)
            {
                GameObject.FindGameObjectWithTag("Teleport").GetComponent<SceneController>().sceneName = "Primavera";
            }
            else if (spring && !summer && !autumn && !winter)
            {
                GameObject.FindGameObjectWithTag("Teleport").GetComponent<SceneController>().sceneName = "Verao";
            }
            else if (spring && summer && !autumn && !winter)
            {
                GameObject.FindGameObjectWithTag("Teleport").GetComponent<SceneController>().sceneName = "Outono";
            }
            else if (spring && summer && autumn && !winter)
            {
                GameObject.FindGameObjectWithTag("Teleport").GetComponent<SceneController>().sceneName = "inverno";
            }
            else if (spring && summer && autumn && winter && GameObject.FindObjectOfType<PosGameController>().posGameEffects == false)
            {
                GameObject.FindGameObjectWithTag("Teleport").GetComponent<SceneController>().sceneName = "Final";
            }
            else if (spring && summer && autumn && winter && GameObject.FindObjectOfType<PosGameController>().posGameEffects == true)
            {
                GameObject.FindGameObjectWithTag("Teleport").GetComponent<SceneController>().sceneName = "PosGameFinal";
            }
            else
            {
                GameObject.FindGameObjectWithTag("Teleport").GetComponent<SceneController>().sceneName = "LabClean";
            }
        }
        else
        {
            return;
        }
    }

    void RestartLevels()
    {
        if(SceneManager.GetActiveScene().name == "Final" || SceneManager.GetActiveScene().name == "PosGameFinal")
        {
            spring = false;
            summer = false;
            autumn = false;
            winter = false;
        }
        else
        {
            return;
        }
    }
}

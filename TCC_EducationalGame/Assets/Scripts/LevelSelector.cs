using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [Header("Levels")]
    public bool spring;
    public bool summer;
    public bool autumn;
    public bool winter;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    
    void Update()
    {
        Levels();
    }

    void Levels()
    {
        if (!spring && !summer && !autumn && !winter)
        {
            GameObject.FindGameObjectWithTag("Teleport").GetComponent<SceneController>().sceneName = "Primavera";
        }
        else if(spring && !summer && !autumn && !winter)
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
        else if(spring && summer && autumn && winter)
        {
            GameObject.FindGameObjectWithTag("Teleport").GetComponent<SceneController>().sceneName = "Final";
        }
        else
        {
            GameObject.FindGameObjectWithTag("Teleport").GetComponent<SceneController>().sceneName = "LabClean";
        }
    }
}

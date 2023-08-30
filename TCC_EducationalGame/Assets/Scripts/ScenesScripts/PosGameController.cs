using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosGameController : MonoBehaviour
{
    public bool posGameActive;

    public bool startChronometer;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (startChronometer)
        {
            GameObject.FindGameObjectWithTag("Chronometer").GetComponent<Chronometer>().StartChronometer();
        }
        else
        {
            GameObject.FindGameObjectWithTag("Chronometer").GetComponent<Chronometer>().StopChronometer();
        }
    }
}

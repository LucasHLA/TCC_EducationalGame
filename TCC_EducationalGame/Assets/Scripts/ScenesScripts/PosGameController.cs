using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosGameController : MonoBehaviour
{
    public bool posGameActive;
    public bool posGameEffects;
    public bool startChronometer;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
      
    }

    void Update()
    {
        
    }
}

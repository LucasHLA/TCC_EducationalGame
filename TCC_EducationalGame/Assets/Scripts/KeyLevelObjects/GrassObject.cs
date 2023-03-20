using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassObject : MonoBehaviour
{

    void Update()
    {
        if (GameObject.FindObjectOfType<LevelSelector>().GetComponent<LevelSelector>().spring == true)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }
        
    }
}

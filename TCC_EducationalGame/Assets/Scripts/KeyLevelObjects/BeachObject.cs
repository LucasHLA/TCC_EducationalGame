using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachObject : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindObjectOfType<LevelSelector>().GetComponent<LevelSelector>().summer == true)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}

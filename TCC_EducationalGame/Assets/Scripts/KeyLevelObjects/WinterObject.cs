using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WinterObject : MonoBehaviour
{
    public SpriteRenderer LevelLight;
    public Light2D light;
    void Update()
    {
        if (GameObject.FindObjectOfType<LevelSelector>().GetComponent<LevelSelector>().winter == true)
        {
            LevelLight.color = Color.green;
            light.color = Color.green;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            LevelLight.color = Color.red;
            light.color = Color.red;
            GetComponent<SpriteRenderer>().color = Color.black;
        }

    }
}

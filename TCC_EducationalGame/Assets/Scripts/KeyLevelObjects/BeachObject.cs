using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using TMPro;

public class BeachObject : MonoBehaviour
{
    public SpriteRenderer LevelLight;
    public Light2D light;

    public GameObject summerTimeObject;
    public TextMeshPro summerTimeText;
    void Update()
    {
        if (GameObject.FindObjectOfType<LevelSelector>().GetComponent<LevelSelector>().summer == true)
        {
            LevelLight.color = Color.green;
            light.color = Color.green;
            GetComponent<SpriteRenderer>().color = Color.white;

            if (GameObject.FindObjectOfType<PosGameController>().posGameEffects == true)
            {
                summerTimeObject.SetActive(true);
                summerTimeText.text = GameObject.FindObjectOfType<PosGameController>().summerTime;
            }
        }
        else
        {
            LevelLight.color = Color.red;
            light.color = Color.red;
            GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}

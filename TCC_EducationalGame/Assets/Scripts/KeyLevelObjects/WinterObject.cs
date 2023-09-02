using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using TMPro;
public class WinterObject : MonoBehaviour
{
    public SpriteRenderer LevelLight;
    public Light2D light;

    public GameObject winterTimeObject;
    public TextMeshPro winterTimeText;
    void Update()
    {
        if (GameObject.FindObjectOfType<LevelSelector>().GetComponent<LevelSelector>().winter == true)
        {
            LevelLight.color = Color.green;
            light.color = Color.green;
            GetComponent<SpriteRenderer>().color = Color.white;

            if (GameObject.FindObjectOfType<PosGameController>().posGameEffects == true)
            {
                winterTimeObject.SetActive(true);
                winterTimeText.text = GameObject.FindObjectOfType<PosGameController>().winterTime;
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

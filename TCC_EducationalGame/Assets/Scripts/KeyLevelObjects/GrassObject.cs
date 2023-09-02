using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using TMPro;
public class GrassObject : MonoBehaviour
{
    public SpriteRenderer LevelLight;
    public Light2D light;
    public GameObject springTimeObject;
    public TextMeshPro springTimeText;


    private void Start()
    {
        
    }
    void Update()
    {
        if (GameObject.FindObjectOfType<LevelSelector>().GetComponent<LevelSelector>().spring == true)
        {
            LevelLight.color = Color.green;
            light.color = Color.green;
            GetComponent<SpriteRenderer>().color = Color.white;

            if(GameObject.FindObjectOfType<PosGameController>().posGameEffects == true)
            {
                springTimeObject.SetActive(true);
                springTimeText.text = GameObject.FindObjectOfType<PosGameController>().springTime;
            }
        }
        else
        {
            LevelLight.color = Color.red;
            light.color = Color.red;
            GetComponent<SpriteRenderer>().color = Color.black;

            if (GameObject.FindObjectOfType<PosGameController>().posGameEffects == false)
            {
                springTimeObject.SetActive(false);
            }
        }
        
    }
}

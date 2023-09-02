using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using TMPro;

public class AutumnObjject : MonoBehaviour
{
    public SpriteRenderer LevelLight;
    public Light2D light;

    public GameObject autumnTimeObject;
    public TextMeshPro autumnTimeText;
    void Update()
    {

        if (GameObject.FindObjectOfType<LevelSelector>().GetComponent<LevelSelector>().autumn == true)
        {
            LevelLight.color = Color.green;
            light.color = Color.green;
            GetComponent<SpriteRenderer>().color = Color.white;

            if (GameObject.FindObjectOfType<PosGameController>().posGameEffects == true)
            {
                autumnTimeObject.SetActive(true);
                autumnTimeText.text = GameObject.FindObjectOfType<PosGameController>().autumnTime;
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

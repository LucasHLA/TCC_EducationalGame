using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LobbyFinalTime : MonoBehaviour
{
    public GameObject finalTimeName;
    public GameObject finalTimeNumber;
    public TextMeshPro finalTimeText;

    void Update()
    {
        if (GameObject.FindObjectOfType<PosGameController>().posGameEffects == true && GameObject.FindObjectOfType<LevelSelector>().winter)
        {
            finalTimeName.SetActive(true);
            finalTimeNumber.SetActive(true);
            finalTimeText.text = GameObject.FindObjectOfType<PosGameController>().finalTime;
        }
        else
        {
            finalTimeName.SetActive(false);
            finalTimeNumber.SetActive(false);
        }
    }
}

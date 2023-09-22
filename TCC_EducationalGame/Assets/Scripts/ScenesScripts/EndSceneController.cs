using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndSceneController : MonoBehaviour
{
    [Header("Normal Final Scene Components")]
    public GameObject textObject;
    public GameObject continueButton;

    [Header("Pós game end scene times")]
    public TextMeshProUGUI springTime;
    public TextMeshProUGUI summerTime;
    public TextMeshProUGUI autumnTime;
    public TextMeshProUGUI winterTime;
    public TextMeshProUGUI finalTime;

    private void Start()
    {
        StartCoroutine(showContinueButton());
    }
    void Update()
    {
        TimeControl();
    }

    IEnumerator showContinueButton()
    {

        yield return new WaitForSeconds(2f);
        continueButton.SetActive(true);
        if (GameObject.FindObjectOfType<PosGameController>().posGameActive != true)
        {
            GameObject.FindObjectOfType<PosGameController>().posGameActive = true;
            GameObject.FindObjectOfType<PosGameController>().posGameEffects = true;
        }
    }

    void TimeControl()
    {
        if(SceneManager.GetActiveScene().name == "PosGameFinal")
        {
            springTime.text = GameObject.FindObjectOfType<PosGameController>().springTime;
            summerTime.text = GameObject.FindObjectOfType<PosGameController>().summerTime;
            autumnTime.text = GameObject.FindObjectOfType<PosGameController>().autumnTime;
            winterTime.text = GameObject.FindObjectOfType<PosGameController>().winterTime;
            finalTime.text = GameObject.FindObjectOfType<PosGameController>().finalTime;
        }
        else
        {
            return;
        }
    }
}

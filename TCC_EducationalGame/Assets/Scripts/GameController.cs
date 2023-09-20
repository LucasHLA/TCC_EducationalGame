using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Level Name and UI")]
    public TextMeshProUGUI LevelNameObject;
    public GameObject levelIndicator;
    public GameObject chronometerText;
    [SerializeField] private float nameShowSpeed;
    public GameObject playerTries;

    [Header("Player related UI")]
    public TextMeshProUGUI tries;
    public GameObject leaf;
    

    [Header("GameOver Panel")]
    public GameObject gameOverPanel;

    void Start()
    {
        if(SceneManager.GetActiveScene().name != "Lab" && SceneManager.GetActiveScene().name != "LabClean")
        {
            tries.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health.ToString();

            if (GameObject.FindObjectOfType<PosGameController>().posGameEffects == true)
            {
                GameObject.FindGameObjectWithTag("Chronometer").GetComponent<Chronometer>().ResetChronometer();
                GameObject.FindGameObjectWithTag("Chronometer").GetComponent<Chronometer>().isCounting = false;
            }
        }
        
        
    }

    void Update()
    {
        StartCoroutine(ShowLevelName());

        if(SceneManager.GetActiveScene().name != "Lab" && SceneManager.GetActiveScene().name != "LabClean")
        {
            tries.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health.ToString();
        }
    }

    IEnumerator ShowLevelName()
    {
        yield return new WaitForSeconds(nameShowSpeed);
        playerTries.SetActive(true);
        levelIndicator.SetActive(true);
        leaf.SetActive(true);

        if (GameObject.FindObjectOfType<PosGameController>().posGameEffects == true)
        {
            if(SceneManager.GetActiveScene().name != "Lab" && SceneManager.GetActiveScene().name != "LabClean")
            {
                chronometerText.SetActive(true);
                GameObject.FindObjectOfType<PosGameController>().startChronometer = true;
                GameObject.FindGameObjectWithTag("Chronometer").GetComponent<Chronometer>().isCounting = true;
            }
        }
        else if(GameObject.FindObjectOfType<PosGameController>().posGameEffects == false)
        {
            if (SceneManager.GetActiveScene().name != "Lab" && SceneManager.GetActiveScene().name != "LabClean")
            {
                chronometerText.SetActive(false);
                GameObject.FindObjectOfType<PosGameController>().startChronometer = false;
                GameObject.FindGameObjectWithTag("Chronometer").GetComponent<Chronometer>().isCounting = false;
            }
        }

    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}

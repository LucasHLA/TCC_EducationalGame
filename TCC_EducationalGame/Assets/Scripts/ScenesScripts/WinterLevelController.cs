using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinterLevelController : MonoBehaviour
{
    [Header("Level Name and UI")]
    public TextMeshProUGUI LevelNameObject;
    public GameObject levelIndicator;
    [SerializeField] private float nameShowSpeed;
    public GameObject playerTries;
    public GameObject robotTries;
    public GameObject bullets;
    public GameObject chronometerText;

    [Header("Player related UI")]
    public TextMeshProUGUI playerTriesText;
    public TextMeshProUGUI robotTriesText;
    public TextMeshProUGUI bulletsAmountText;
    public GameObject barrier;
    public GameObject barrierController;

    [Header("GameOver Panel")]
    public GameObject gameOverPanel;

    [Header("Camera Related")]
    public GameObject playerCamera;
    public GameObject robotCamera; 

    void Start()
    {
        playerTriesText.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health.ToString();
        StartCoroutine(ShowLevelName());

        if (GameObject.FindObjectOfType<PosGameController>().posGameEffects == true)
        {
            GameObject.FindGameObjectWithTag("Chronometer").GetComponent<Chronometer>().ResetChronometer();
            GameObject.FindGameObjectWithTag("Chronometer").GetComponent<Chronometer>().isCounting = false;
        }
    }

    void Update()
    {
        ChangeCamera();

        playerTriesText.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health.ToString();
        robotTriesText.text = GameObject.FindGameObjectWithTag("Robot").GetComponent<TankerRobot>().health.ToString();
        bulletsAmountText.text = GameObject.FindGameObjectWithTag("Robot").GetComponent<TankerRobot>().bullets.ToString();

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health < 0)
        {
            ShowGameOver();
        }
    }

    IEnumerator ShowLevelName()
    {
        yield return new WaitForSeconds(nameShowSpeed);
        playerTries.SetActive(true);
        levelIndicator.SetActive(true);

        if (GameObject.FindObjectOfType<PosGameController>().posGameEffects == true)
        {
            chronometerText.SetActive(true);
            GameObject.FindObjectOfType<PosGameController>().startChronometer = true;
            GameObject.FindGameObjectWithTag("Chronometer").GetComponent<Chronometer>().isCounting = true;

        }
        else if (GameObject.FindObjectOfType<PosGameController>().posGameEffects == false)
        {
            chronometerText.SetActive(false);
            GameObject.FindObjectOfType<PosGameController>().startChronometer = false;
            GameObject.FindGameObjectWithTag("Chronometer").GetComponent<Chronometer>().isCounting = false;

        }
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void DesactivateBarrier()
    {
        if (GameObject.FindObjectOfType<BossSceneLogic>().GetComponent<BossSceneLogic>().isDestroyed == true)
        {
            barrier.SetActive(false);
            barrierController.SetActive(false);
        }
    }

    void ChangeCamera()
    {
        if (playerCamera.activeInHierarchy == true)
        {
            playerTries.SetActive(true);
            robotTries.SetActive(false);
            bullets.SetActive(false);
        }
        else if (robotCamera.activeInHierarchy == true)
        {
            playerTries.SetActive(false);
            robotTries.SetActive(true);
            bullets.SetActive(true);
        }
    }
}

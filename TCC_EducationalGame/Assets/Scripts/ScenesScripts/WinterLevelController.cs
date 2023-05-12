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

    [Header("Player related UI")]
    public TextMeshProUGUI playerTriesText;
    public TextMeshProUGUI robotTriesText;
    public TextMeshProUGUI bulletsAmountText;

    [Header("GameOver Panel")]
    public GameObject gameOverPanel;

    [Header("Camera Related")]
    public GameObject playerCamera;
    public GameObject robotCamera;

    void Start()
    {
        playerTriesText.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health.ToString();
        StartCoroutine(ShowLevelName());
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
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
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

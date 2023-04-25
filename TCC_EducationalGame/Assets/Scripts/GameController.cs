using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Level Name and UI")]
    public TextMeshProUGUI LevelNameObject;
    public GameObject levelIndicator;
    [SerializeField] private float nameShowSpeed;
    public GameObject canvas;

    [Header("Player related UI")]
    public TextMeshProUGUI tries;
    public TextMeshProUGUI bossTries;

    [Header("GameOver Panel")]
    public GameObject gameOverPanel;

    void Start()
    {
        tries.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health.ToString();
        bossTries.text = GameObject.FindGameObjectWithTag("Bear").GetComponent<Bear>().lives.ToString();
    }

    void Update()
    {
        StartCoroutine(ShowLevelName());
        tries.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health.ToString();
        bossTries.text = GameObject.FindGameObjectWithTag("Bear").GetComponent<Bear>().lives.ToString();
    }

    IEnumerator ShowLevelName()
    {
        yield return new WaitForSeconds(nameShowSpeed);
        canvas.SetActive(true);
        levelIndicator.SetActive(true);

    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Level Name and UI")]
    public TextMeshProUGUI LevelNameObject;
    public string LevelName;
    public GameObject levelIndicator;
    [SerializeField] private float nameShowSpeed;

    void Start()
    {
        LevelNameObject.text = LevelName;
    }

    void Update()
    {
        StartCoroutine(ShowLevelName());
    }

    IEnumerator ShowLevelName()
    {
        yield return new WaitForSeconds(nameShowSpeed);
        levelIndicator.SetActive(true);
    }
}

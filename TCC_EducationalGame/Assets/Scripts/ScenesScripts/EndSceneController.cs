using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneController : MonoBehaviour
{
    [Header("Normal Final Scene Components")]
    public GameObject textObject;
    public GameObject continueButton;
    public GameObject levelSelector;

    private void Awake()
    {
        levelSelector = GameObject.FindObjectOfType<LevelSelector>().gameObject;
    }
    void Start()
    {
        Destroy(levelSelector);
    }
    void Update()
    {
        continueButton.SetActive(true);
    }

    IEnumerator showContinueButton()
    {

        yield return new WaitForSeconds(1.2f);
        continueButton.SetActive(true);
        if (GameObject.FindObjectOfType<PosGameController>().posGameActive != true)
        {
            GameObject.FindObjectOfType<PosGameController>().posGameActive = true;
            GameObject.FindObjectOfType<PosGameController>().posGameEffects = true;
        }
    }
}

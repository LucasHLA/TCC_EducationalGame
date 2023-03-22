using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    public static LetterController instance;

    [Header("Letters Controller")]
    public GameObject[] lettersController;
    private LettersInUI lUI;
    public int index = -1;
    public string letterTag;

    [Header("Counting the letters in the level")]
    public LayerMask letterLayer;
    public int totalLetters;
    public int countLetters;
    public bool canTeleport;

    void Start()
    {
        instance = this;
        lUI = GameObject.FindObjectOfType<LettersInUI>().GetComponent<LettersInUI>();
        totalLetters = lettersController.Length;
    }

    void Update()
    {
        lUI.index = index;
        CheckingLetters();
        if(countLetters >= totalLetters)
        {
            canTeleport = true;
        }
        else
        {
            canTeleport = false;
        }
    }

    private void CheckingLetters()
    {
        switch (letterTag)
        {
            case "F":
                lUI.index = 0;
                break;

            case "L":
                lUI.index = 1;
                break;

            case "O":
                lUI.index = 2;
                break;

            case "R":
                lUI.index = 3;
                break;
        }
    }

    private int CountObjectsOnLayer()
    {
        int count = 0;

        foreach (GameObject gameObject in lettersController)
        {
            
                count++;
            
        }

        return count;
    }
}

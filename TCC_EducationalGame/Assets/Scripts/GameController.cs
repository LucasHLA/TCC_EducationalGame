using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [Header("Letters Controller")]
    public GameObject[] lettersController;
    private LettersInUI lUI;
    public int index = -1;
    public string tag;
    void Start()
    {
        instance = this;
        lUI = GameObject.FindObjectOfType<LettersInUI>().GetComponent<LettersInUI>();
    }

    void Update()
    {
        lUI.index = index;
        //CheckingLetters();
    }

    private void CheckingLetters()
    {
        /*We need to make another switch, to check wich letter is being taken.
        to make sure they dont get the wrong letter and we show the right one, we need to check the tags*/

        switch (index)
        {
            case 0:
                lUI.index = 0;
                break;

            case 1:
                lUI.index = 1;
                break;

            case 2:
                lUI.index = 2;
                break;

            case 3:
                lUI.index = 3;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LettersInUI : MonoBehaviour
{
    public Letter letter;

    [Header("UI Related")]
    public Image[] letters;
    public GameObject[] lettersInOrder;
    public int index = -1;
    
    void Update()
    {
        if(index >= 0)
        {
            lettersInOrder[index].SetActive(true);
            letters[index].sprite = letter.lettersSprites[index];
        }
    }
}

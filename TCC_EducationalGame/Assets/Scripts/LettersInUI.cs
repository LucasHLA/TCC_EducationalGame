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
    void Start()
    {
        
        for (int i = 0; i <= lettersInOrder.Length; i++)
        {
            lettersInOrder[i].SetActive(false);
        } 
    }

    void Update()
    {
        lettersInOrder[index].SetActive(true);
        letters[index].sprite = letter.lettersSprites[index];
    }
}

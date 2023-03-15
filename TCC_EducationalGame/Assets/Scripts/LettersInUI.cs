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


    // Letters Array s�o as imagens dos objetos que a gente coloca na cena � s� referenciar
    // lettersInOrder � a mesma coisa s� que n�o est� pegando a imagem e sim o objeto em si.
    void Update()
    {
        if(index >= 0)
        {
            lettersInOrder[index].SetActive(true);
            letters[index].sprite = letter.lettersSprites[index];
        }
    }
}

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


    // Letters Array são as imagens dos objetos que a gente coloca na cena é só referenciar
    // lettersInOrder é a mesma coisa só que não está pegando a imagem e sim o objeto em si.
    void Update()
    {
        if(index >= 0)
        {
            lettersInOrder[index].SetActive(true);
            letters[index].sprite = letter.lettersSprites[index];
        }
    }
}

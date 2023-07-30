using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InformationText : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public GameObject levelObject;
    public GameObject continueButton;
    public string[] lines;
    public float textSpeed;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
    }

    void Update()
    {

    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char  c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(0.5f);
        levelObject.SetActive(true);


        yield return new WaitForSeconds(0.7f);
        continueButton.SetActive(true);
    }

    public void NextLine()
    {
        if(index < lines.Length)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Type());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}

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
        // Certifique-se de que textComponent n�o seja nulo
        if (textComponent != null)
        {
            textComponent.text = string.Empty;
            StartDialogue(); // Comece o di�logo imediatamente, se desejar
        }
        else
        {
            Debug.LogError("O TextMeshProUGUI n�o est� atribu�do ao componente!");
        }
    }

    void Update()
    {
        // Se desejar, voc� pode adicionar l�gica de avan�o de linha aqui
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(Type(lines[index])); // Passe a linha diretamente para Type
    }

    IEnumerator Type(string line)
    {
        // Use a linha passada como argumento
        textComponent.text = line;

        yield return new WaitForSeconds(0.5f);
        levelObject.SetActive(true);

        yield return new WaitForSeconds(0.7f);
        continueButton.SetActive(true);
    }

    public void NextLine()
    {
        if (index < lines.Length)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Type(lines[index])); // Passe a pr�xima linha diretamente para Type
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}

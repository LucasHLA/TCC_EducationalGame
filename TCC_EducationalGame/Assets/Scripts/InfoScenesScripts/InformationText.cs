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
        // Certifique-se de que textComponent não seja nulo
        if (textComponent != null)
        {
            textComponent.text = string.Empty;
            StartDialogue(); // Comece o diálogo imediatamente, se desejar
        }
        else
        {
            Debug.LogError("O TextMeshProUGUI não está atribuído ao componente!");
        }
    }

    void Update()
    {
        // Se desejar, você pode adicionar lógica de avanço de linha aqui
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
            StartCoroutine(Type(lines[index])); // Passe a próxima linha diretamente para Type
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}

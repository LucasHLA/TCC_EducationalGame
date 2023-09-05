using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InformationText : MonoBehaviour
{
    public GameObject levelObject;
    public GameObject continueButton;

    public void activateComponents()
    { 
        StartCoroutine(activateSceneComponents());
    }
    IEnumerator activateSceneComponents()
    {
        yield return new WaitForSeconds(0.5f);
        levelObject.SetActive(true);

        yield return new WaitForSeconds(0.7f);
        continueButton.SetActive(true);
    }
}

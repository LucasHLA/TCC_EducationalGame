using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationController : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject levelObject;
    public GameObject target;

    public void Continue()
    {
        continueButton.SetActive(false);
        levelObject.SetActive(false);
        GameObject.FindObjectOfType<InformationText>().textComponent.text = string.Empty;
        target.transform.position = new Vector3(+690,transform.position.y,transform.position.z);
    }
}

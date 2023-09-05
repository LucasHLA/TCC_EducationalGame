using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationController : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject levelObject;
    public GameObject textObject;
    public GameObject target;
    public GameObject teleporter;

    public void Continue()
    {
        continueButton.SetActive(false);
        levelObject.SetActive(false);
        textObject.SetActive(false);
        target.transform.position = new Vector3(+1500,transform.position.y,transform.position.z);
        teleporter.transform.position = new Vector3(+1410, 3f, transform.position.z);
    }
}

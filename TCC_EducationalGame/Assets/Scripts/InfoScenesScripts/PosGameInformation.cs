using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosGameInformation : MonoBehaviour
{
    [Header("Normal Game Related")]
    public GameObject character;
    public GameObject normalText;
    public GameObject levelObject;
    public GameObject normalButton;

    [Header("Pos Game Related")]
    public GameObject posGameObject;
    public GameObject RewardImage;
    public GameObject continueButton;
    public GameObject rewardText;
    public GameObject galleryText;
    public GameObject saveButton;
    void Update()
    {
        if(GameObject.FindObjectOfType<PosGameController>().posGameEffects == true)
        {
            posGameObject.SetActive(true);
            Destroy(character);
            Destroy(normalText);
            Destroy(normalButton);
            Destroy(levelObject);
        }
        else if(GameObject.FindObjectOfType<PosGameController>().posGameEffects == false)
        {
            character.SetActive(true);
            posGameObject.SetActive(false);
        }
    }

    public void PosGameContinue()
    {
        continueButton.SetActive(false);
        RewardImage.SetActive(false);
        rewardText.SetActive(false);
        saveButton.SetActive(false);
        galleryText.SetActive(false);
        GameObject.FindObjectOfType<SceneController>().ChangeScene();

    }
}

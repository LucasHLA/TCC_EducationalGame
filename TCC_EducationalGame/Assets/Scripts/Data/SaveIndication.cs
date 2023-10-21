using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveIndication : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Objects")]

    public GameObject menuTextIndicator;
    public GameObject saveText;
    public GameObject saveTextSucess;
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        menuTextIndicator.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        menuTextIndicator.SetActive(false);
    }

    public void OnClickText()
    {
        saveTextSucess.SetActive(true);
        saveText.SetActive(false);
    }
}

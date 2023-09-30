using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GalleryLockedImages : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [Header("Objects")]

    public GameObject padlock;
    public GameObject text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        padlock.SetActive(false);
        text.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        padlock.SetActive(true);
        text.SetActive(false);
    }
}

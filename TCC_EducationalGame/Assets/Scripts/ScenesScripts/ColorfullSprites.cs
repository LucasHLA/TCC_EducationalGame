using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColorfullSprites : MonoBehaviour
{
    public Image[] images;
    public float speed = 1f; 

    void Start()
    {

    }

    void Update()
    {
        for (int i = 0; i < images.Length; i++)
        {
            float offset = Time.time * speed;
            Color newColor = new Color(Mathf.Sin(offset), Mathf.Sin(offset + 2f), Mathf.Sin(offset + 4f));

            images[i].color = newColor;
        }
    }
}

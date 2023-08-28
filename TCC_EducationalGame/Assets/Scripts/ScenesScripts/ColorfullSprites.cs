using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColorfullSprites : MonoBehaviour
{
    public Image[] images;

    public float speed = 1f;

    public GameObject startButton;
    public GameObject exitButton;
    public GameObject startTimeButton;
    public GameObject conclusionStar;

    void Update()
    {
        for (int i = 0; i < images.Length; i++)
        {
            float offset = Time.time * speed;
            Color newColor = new Color(Mathf.Sin(offset), Mathf.Sin(offset + 2f), Mathf.Sin(offset + 4f));

            images[i].color = newColor;
        }

        StartCoroutine(ShowButtons());
    }

    IEnumerator ShowButtons()
    {
        yield return new WaitForSeconds(2.4f);
        startButton.gameObject.transform.position = new Vector3(startButton.transform.position.x, startButton.transform.position.y,0);

        yield return new WaitForSeconds(0.7f);
        if (GameObject.FindObjectOfType<PosGameController>().posGameActive)
        {
            conclusionStar.SetActive(true);
        }

        yield return new WaitForSeconds(0.7f);
        exitButton.gameObject.transform.position = new Vector3(exitButton.transform.position.x, exitButton.transform.position.y, 0);
        
        yield return new WaitForSeconds(0.7f);
        if (GameObject.FindObjectOfType<PosGameController>().posGameActive)
        {
            startTimeButton.gameObject.transform.position = new Vector3(startTimeButton.transform.position.x, startTimeButton.transform.position.y, 0);
        }
        else
        {
            yield return 0;
        }
    }
}

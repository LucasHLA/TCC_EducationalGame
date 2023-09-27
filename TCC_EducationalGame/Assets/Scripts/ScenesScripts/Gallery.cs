using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gallery : MonoBehaviour
{
    [Header("Image padlocks array")]
    public GameObject[] imageLocks;

    [Header("Images")]
    public string imageName;

    void Update()
    {
        UnlockImages();
    }

    void UnlockImages()
    {
        if (GameObject.FindObjectOfType<PosGameController>().unlockSpring)
        {
            imageLocks[0].SetActive(false);
        }
        if (GameObject.FindObjectOfType<PosGameController>().unlockSummer)
        {
            imageLocks[1].SetActive(false);
        }
        if (GameObject.FindObjectOfType<PosGameController>().unlockAutumn)
        {
            imageLocks[2].SetActive(false);
        }
        if (GameObject.FindObjectOfType<PosGameController>().unlockWinter)
        {
            imageLocks[3].SetActive(false);
        }
        //if (GameObject.FindObjectOfType<PosGameController>().unlockCientist)
        //{
        //    imageLocks[4].SetActive(false);
        //}
        //if (GameObject.FindObjectOfType<PosGameController>().unlockBoss)
        //{
        //    imageLocks[5].SetActive(false);
        //}
        //if (GameObject.FindObjectOfType<PosGameController>().unlockSeasons)
        //{
        //    imageLocks[6].SetActive(false);
        //}
        //if (GameObject.FindObjectOfType<PosGameController>().unlockRobots)
        //{
        //    imageLocks[7].SetActive(false);
        //}
    }
}

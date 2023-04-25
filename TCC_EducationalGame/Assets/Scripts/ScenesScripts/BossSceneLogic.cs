using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSceneLogic : MonoBehaviour
{
    [Header("Boss scene components")]
    public GameObject cameraTrigger;
    public GameObject leftCollider;
    public GameObject rightCollider;
    public GameObject mainCamera;
    public GameObject bossCamera;
    public GameObject bear;
    public GameObject bossLives;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mainCamera.SetActive(false);
            bossCamera.SetActive(true);
            bossLives.SetActive(true);
        }
    }

    private void Update()
    {
        if(bear.activeInHierarchy == false)
        {
            mainCamera.SetActive(true);
            bossCamera.SetActive(false);
            leftCollider.SetActive(false);
            rightCollider.SetActive(false);
            bossLives.SetActive(false);
        }
    }


}

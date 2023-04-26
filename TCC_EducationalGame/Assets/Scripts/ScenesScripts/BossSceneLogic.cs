using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossSceneLogic : MonoBehaviour
{
    [Header("Boss scene components")]
    public GameObject cameraTrigger;
    public GameObject leftCollider;
    public GameObject rightCollider;
    public GameObject mainCamera;
    public GameObject bossCamera;
    public GameObject bear;
    public GameObject bossTries;
    public TextMeshProUGUI bossTriesUI;

    private void Start()
    {
        bossTriesUI.text = GameObject.FindGameObjectWithTag("Bear").GetComponent<Bear>().lives.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mainCamera.SetActive(false);
            bossCamera.SetActive(true);
            bossTries.SetActive(true);
        }
    }

    private void Update()
    {
        bossTriesUI.text = GameObject.FindGameObjectWithTag("Bear").GetComponent<Bear>().lives.ToString();

        if (bear.activeInHierarchy == false)
        {
            mainCamera.SetActive(true);
            bossCamera.SetActive(false);
            leftCollider.SetActive(false);
            rightCollider.SetActive(false);
            bossTries.SetActive(false);
        }
    }


}

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
    public bool isDestroyed;
    public bool active;
    public GameObject bossTries;
    public GameObject letterDrop;
    public TextMeshProUGUI bossTriesUI;

    private void Start()
    {
        bossTriesUI.text = GameObject.FindGameObjectWithTag("Bear").GetComponent<Bear>().lives.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !active)
        {
            mainCamera.SetActive(false);
            bossCamera.SetActive(true);
            bossTries.SetActive(true);
            active = true;
        }
    }

    private void Update()
    {
        if(!isDestroyed)
        {
            bossTriesUI.text = GameObject.FindGameObjectWithTag("Bear").GetComponent<Bear>().lives.ToString();
        }

        BossDefeated();
    }

    void BossDefeated()
    {
        if (isDestroyed)
        {
            StartCoroutine(ChangeCamera());
            leftCollider.SetActive(false);
            rightCollider.SetActive(false);
            bossTries.SetActive(false);
        }
    }

    IEnumerator ChangeCamera()
    {
        yield return new WaitForSeconds(1.7f);
        mainCamera.SetActive(true);
        bossCamera.SetActive(false);
        this.gameObject.SetActive(false);
    }
}

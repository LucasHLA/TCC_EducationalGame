using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public GameObject levelName;
    //Make the transition longer and actually create a transition before hte scenes with a nice little music or something that feels nice


    private void Update()
    {
        StartCoroutine(ShowName());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ClearTransition());
        }
    }

    IEnumerator ClearTransition()
    {
        GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>().SetTrigger("end");
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadSceneAsync(sceneName);
        
    }
    IEnumerator ShowName()
    {
        yield return new WaitForSeconds(1.75f);
        levelName.SetActive(true);
    }
}

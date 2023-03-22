using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : SceneController
{

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
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(sceneName);

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLevel : SceneController
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player") && 
            GameObject.FindObjectOfType<LetterController>().GetComponent<LetterController>().canTeleport == true)
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

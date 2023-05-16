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
            if(SceneManager.GetActiveScene().name == "Inverno")
            {
                GameObject.FindObjectOfType<WinterLevelController>().GetComponent<WinterLevelController>().playerTries.SetActive(false);
            }
            else
            {
                GameObject.FindObjectOfType<GameController>().GetComponent<GameController>().playerTries.SetActive(false);
            }
            StartCoroutine(ClearTransition());
        }
    }

    IEnumerator ClearTransition()
    {
        GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>().SetTrigger("end");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);

    }
}

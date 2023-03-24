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
            GameObject.FindObjectOfType<GameController>().GetComponent<GameController>().canvas.SetActive(false);
            StartCoroutine(ClearTransition());
        }
    }

    IEnumerator ClearTransition()
    {
        GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>().SetTrigger("end");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);

    }
    //Call this method when the player lose all the tries
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

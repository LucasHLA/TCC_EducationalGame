using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLevel : SceneController
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Finish the object logic here hwre the player gets the flower and turn the grass true on level selector and the player can go further in the game without taking it 
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string sceneName;
    //Make the transition longer and actually create a transition before hte scenes with a nice little music or something that feels nice

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ClearTransition());
        }
    }

    IEnumerator ClearTransition()
    {
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadSceneAsync(sceneName);
    }
}

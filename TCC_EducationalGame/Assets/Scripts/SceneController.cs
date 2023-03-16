using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string sceneName;
    //Make the transition longer and actually create a transition before hte scenes with a nice little music or something that feels nice
    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LoadScene();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string sceneName;
    public float transitionTime;

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);

        if(GameObject.FindObjectOfType<PosGameController>().posGameEffects == true)
        {
            GameObject.FindObjectOfType<Chronometer>().StopChronometer();
            GameObject.FindObjectOfType<PosGameController>().accumulatedTime = 0f;
        }
    }

    public void PosGameStart()
    {
        SceneManager.LoadScene(sceneName);
        GameObject.FindObjectOfType<PosGameController>().posGameEffects = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

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
    }

    public void PosGameStart()
    {
        SceneManager.LoadScene("LabClean");
        GameObject.FindObjectOfType<PosGameController>().posGameEffects = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

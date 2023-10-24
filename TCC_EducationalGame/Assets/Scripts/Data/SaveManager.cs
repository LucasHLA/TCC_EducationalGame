using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public GameObject sucessText;
    public void SaveGame()
    {
        GameObject.FindObjectOfType<SaveToJSON>().SaveGame();
        Debug.Log("save");
    }

    public void SaveAndSucess()
    {
        GameObject.FindObjectOfType<SaveToJSON>().SaveGame();
        sucessText.SetActive(true);
        Debug.Log("Save");
    }

    public void LoadGame()
    {
        GameObject.FindObjectOfType<SaveToJSON>().LoadGame();
    }

    public void DeleteData()
    {
        GameObject.FindObjectOfType<SaveToJSON>().DeleteData();
    }

}

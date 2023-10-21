using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public void SaveGame()
    {
        GameObject.FindObjectOfType<SaveToJSON>().SaveGame();
        Debug.Log("save");
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

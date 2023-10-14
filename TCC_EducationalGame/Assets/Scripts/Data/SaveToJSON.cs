using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveToJSON : MonoBehaviour
{
    public static SaveToJSON instance;

    private string savePath;
    private SaveData saveData;
    private string saveDirectory;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            saveData = new SaveData();
        }

        saveDirectory = Application.persistentDataPath + "/Saves/";

        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }

        savePath = saveDirectory + "SaveSlot.json";

        Debug.Log("Awake!");
    }

    public void SaveGame()
    {
        saveData.posGameActive = GameObject.FindObjectOfType<PosGameController>().posGameActive;
        saveData.springGallery = GameObject.FindObjectOfType<PosGameController>().unlockSpring;
        saveData.summerGallery = GameObject.FindObjectOfType<PosGameController>().unlockSummer;
        saveData.autumnGallery = GameObject.FindObjectOfType<PosGameController>().unlockAutumn;
        saveData.winterGallery = GameObject.FindObjectOfType<PosGameController>().unlockWinter;
        saveData.cientistGallery = GameObject.FindObjectOfType<PosGameController>().unlockCientist;
        saveData.seasonsGallery = GameObject.FindObjectOfType<PosGameController>().unlockSeasons;
        saveData.robotsGallery = GameObject.FindObjectOfType<PosGameController>().unlockRobots;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(savePath, json);
        Debug.Log("Save");
    }

    public void LoadGame()
    {
        string json = File.ReadAllText(savePath);
        saveData = JsonUtility.FromJson<SaveData>(json);


        GameObject.FindObjectOfType<PosGameController>().posGameActive = saveData.posGameActive;
        GameObject.FindObjectOfType<PosGameController>().unlockSpring = saveData.springGallery;
        GameObject.FindObjectOfType<PosGameController>().unlockSummer = saveData.summerGallery;
        GameObject.FindObjectOfType<PosGameController>().unlockAutumn = saveData.autumnGallery;
        GameObject.FindObjectOfType<PosGameController>().unlockWinter = saveData.winterGallery;
        GameObject.FindObjectOfType<PosGameController>().unlockCientist = saveData.cientistGallery;
        GameObject.FindObjectOfType<PosGameController>().unlockSeasons = saveData.seasonsGallery;
        GameObject.FindObjectOfType<PosGameController>().unlockRobots = saveData.robotsGallery;
        Debug.Log("Load");
    }

    public void DeleteData()
    {

        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
        else
        {
            return;
        }
        
    }

}

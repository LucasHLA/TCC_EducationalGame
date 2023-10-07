using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;

public class FolderManager : MonoBehaviour
{
    private string saveDirectory;
    public void OpenFolder()
    {

        saveDirectory = Application.persistentDataPath + "/Recompensas/";

        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }
        string filePath = saveDirectory + "/";

        string directoryPath = Path.GetDirectoryName(filePath);
        Process.Start("explorer.exe", directoryPath);
    }
}

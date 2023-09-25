using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;

public class FolderManager : MonoBehaviour
{
    public void OpenFolder()
    {
        string filePath = Application.persistentDataPath + "/";

        string directoryPath = Path.GetDirectoryName(filePath);
        Process.Start("explorer.exe", directoryPath);
    }
}

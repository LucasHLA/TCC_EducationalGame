using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    public Image coloringImage; // A referência para o componente Image que exibe o desenho para colorir
    public string nome;
    public void SaveImage()
    {
        // Obtém a sprite da imagem exibida no componente Image
        Sprite sprite = coloringImage.sprite;

        // Obtém a textura da sprite
        Texture2D texture = sprite.texture;

        // Converte a textura em uma matriz de bytes no formato JPG (ou JPEG)
        byte[] bytes = texture.EncodeToJPG(); // Use EncodeToJPG para JPEG

        // Define o caminho de destino para salvar a imagem (pode ser ajustado conforme necessário)
        string filePath = Application.persistentDataPath + "/" + nome + ".jpg";

        string directoryPath = Path.GetDirectoryName(filePath);
        Process.Start("explorer.exe", directoryPath);

        // Salva a matriz de bytes como um arquivo JPG
        File.WriteAllBytes(filePath, bytes);
    }
}

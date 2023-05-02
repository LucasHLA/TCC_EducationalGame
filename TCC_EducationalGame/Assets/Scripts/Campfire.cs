using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Campfire : MonoBehaviour
{
    public Light2D campfireLight;
    public float minIntensity = 0.4f;
    public float maxIntensity = 1.0f;
    public float flickerSpeed = 0.05f;
    public float flickerAmount = 0.1f;
    public Gradient colorGradient;

    private float targetIntensity;
    private float currentIntensity;
    private float flickerTimer;
    private float flickerOffset;
    private Color targetColor;
    private Color currentColor;

    void Start()
    {
        targetIntensity = Random.Range(minIntensity, maxIntensity);
        currentIntensity = targetIntensity;
        flickerTimer = Random.value;
        flickerOffset = Random.value;
        targetColor = colorGradient.Evaluate(Random.value);
        currentColor = targetColor;
    }

    void Update()
    {
        // Flicker the light
        flickerTimer += Time.deltaTime * flickerSpeed;
        float noise = Mathf.PerlinNoise(flickerOffset + flickerTimer, 0.0f) * 2.0f - 1.0f;
        currentIntensity = Mathf.Lerp(currentIntensity, targetIntensity + noise * flickerAmount, Time.deltaTime * 10.0f);
        campfireLight.intensity = currentIntensity;

        // Change the color of the light
        float t = Mathf.PingPong(Time.time, 1.0f);
        currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * 5.0f);
        campfireLight.color = currentColor;

        if (t == 0.0f)
        {
            targetColor = colorGradient.Evaluate(Random.value);
        }

        if (Mathf.Abs(targetIntensity - currentIntensity) < 0.01f)
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}

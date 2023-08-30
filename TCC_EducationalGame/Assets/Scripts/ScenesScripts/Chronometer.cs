using UnityEngine;
using UnityEngine.UI;

public class Chronometer : MonoBehaviour
{
    public Text timerText;

    private float startTime;
    public bool isRunning;

    void Start()
    {
        ResetChronometer();
    }

    void Update()
    {
        if (isRunning)
        {
            float elapsedTime = Time.time - startTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);

            string formattedTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
            timerText.text = formattedTime;
        }

        
    }

    public void StartChronometer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopChronometer()
    {
        isRunning = false;
    }

    public void ResetChronometer()
    {
        timerText.text = "00:00:000";
        startTime = 0f;
        isRunning = false;
    }
}

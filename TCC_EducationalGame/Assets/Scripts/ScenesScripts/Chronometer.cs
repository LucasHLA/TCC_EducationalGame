using UnityEngine;
using UnityEngine.UI;

public class Chronometer : MonoBehaviour
{
    public Text timerText;
    public bool isCounting = false;

    private float startTime;

    void Update()
    {
        if (isCounting && GameObject.FindObjectOfType<PosGameController>().startChronometer)
        {
            float elapsedTime = Time.timeSinceLevelLoad;

            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);

            string formattedTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
            timerText.text = formattedTime;

            GameObject.FindObjectOfType<PosGameController>().accumulatedTime = elapsedTime;
            
        }
    }

    public void StartChronometer()
    {
        startTime = Time.time;
        isCounting = true;
    }

    public void StopChronometer()
    {
        isCounting = false;
    }

    public void ResetChronometer()
    {
        timerText.text = "00:00:000";
        startTime = 0f;
    }
}

using System.Data;
using TMPro;
using UnityEngine;

public class GameClock : MonoBehaviour
{
    public TextMeshProUGUI gameClock;
    public Transform sun;
    public float timeMultiplier = 200f;

    private float gameTimeInSeconds;

    private int hours = 8;
    private int minutes = 15;
    
    public int currentMinutes;
    public int currentHours;
    private void Update()
    {
        gameTimeInSeconds += Time.deltaTime * timeMultiplier;
        int totalMinutes = (int)(gameTimeInSeconds / 60);  // Total in-game minutes

        currentMinutes = (minutes + totalMinutes) % 60;
        currentHours = (hours + (minutes + totalMinutes) / 60) % 24;

        float timeInDay = currentHours + (currentMinutes / 60f);
        float sunRotation = (timeInDay / 24f) * 360f;

        sun.transform.rotation = Quaternion.Euler(sunRotation - 90f, 170f, 0f);
        gameClock.text = string.Format("{0:D2}:{1:D2}", currentHours, currentMinutes);

    }
}


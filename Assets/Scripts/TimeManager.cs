using UnityEngine;
using System;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    void Awake()
    {
        DateTime now = DateTime.UtcNow;

        if (PlayerPrefs.HasKey("lastTime"))
        {
            long ticks = long.Parse(PlayerPrefs.GetString("lastTime"));
            DateTime last = new DateTime(ticks, DateTimeKind.Utc);
            TimeSpan away = now - last;
            text.text = away.TotalHours.ToString();
        }
    }
    
    void OnApplicationPause(bool paused)
    {
        if (paused) SaveTime();
    }

    void OnApplicationQuit() => SaveTime();

    void SaveTime()
    {
        PlayerPrefs.SetString("lastTime", DateTime.UtcNow.Ticks.ToString());
        PlayerPrefs.Save();
    }
}

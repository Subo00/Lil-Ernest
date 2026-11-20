using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public StatsKeeper statsKeeper;
    TimeSpan away;
    void Awake()
    {
        if(Instance == null) { Destroy(gameObject); }
        else { Instance = this; }  
    }

    private void Start()
    {
        UpdateStats();
    }

    void OnApplicationPause(bool paused)
    {
        if (!paused) UpdateStats();
    }

    private void UpdateStats()
    {
        DateTime now = DateTime.UtcNow;

        if (!PlayerPrefs.HasKey("lastTime")) { Debug.LogError("time is not saved"); return; }
        
        long ticks = long.Parse(PlayerPrefs.GetString("lastTime"));
        DateTime last = new DateTime(ticks, DateTimeKind.Utc);
        away = now - last;

        statsKeeper.UpdateStatsHourly((float)away.TotalHours);
    }
}

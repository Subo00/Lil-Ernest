using UnityEngine;
using TMPro;

public class StatsKeeper : MonoBehaviour
{
    float hungerPerHour = 10f;
    float happinessPerHour = 15f;
    float hygienePerHour = 2f;
    public class HumanData
    {
        public float hunger = 100f;
        public float hygiene = 100f;
        public float happiness = 100f;
        public float energy = 5f;
    }
    [SerializeField] private TextMeshProUGUI text;
    public HumanData humanData = new HumanData();

    private void Awake()
    {
        humanData = Load();          
    }
    public void UpdateStatsHourly(float hours)
    {
        humanData.hunger = Mathf.Clamp(humanData.hunger - hours * hungerPerHour, 0f, 100f);
        humanData.happiness = Mathf.Clamp(humanData.happiness - hours * happinessPerHour, 0f, 100f);
        humanData.hygiene = Mathf.Clamp(humanData.hygiene - hours * hygienePerHour, 0f, 100f);

        Save(humanData);
        text.text = "HUNGER:" + humanData.hunger.ToString();
        Debug.Log("PLL " +  humanData.hunger);
    }
    private void Start()
    {
        humanData = Load();
        text.text = "HUNGER:" + humanData.hunger.ToString();

    }

    void OnApplicationPause(bool paused)
    {
        if (paused) Save(humanData);
    }

    void OnApplicationQuit() => Save(humanData);

    void Save(HumanData data)
    {
        PlayerPrefs.SetString("data", JsonUtility.ToJson(data));
        PlayerPrefs.Save();
    }

    HumanData Load()
    {
        if(!PlayerPrefs.HasKey("data")) return new HumanData();
        return JsonUtility.FromJson<HumanData>(PlayerPrefs.GetString("data"));
    }

}

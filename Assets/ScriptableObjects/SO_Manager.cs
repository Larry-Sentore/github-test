using UnityEngine;


public class SO_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerInfo_SO playerInfo;
    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI levelText;
    public TMPro.TextMeshProUGUI healthText;
    public TMPro.TextMeshProUGUI volumeText;
    public TMPro.TextMeshProUGUI playerNameText;
    public TMPro.TextMeshProUGUI sensitivityText;
    public UnityEngine.UI.Slider volumeSlider;

    void Start()
    {
        nameText.text = playerInfo.playerName;
        levelText.text = playerInfo.playerLevel.ToString();
        healthText.text = playerInfo.playerHealth.ToString();

        if (volumeSlider == null || volumeText == null ||
            playerNameText == null || sensitivityText == null)
        {
            Debug.LogError(
                "Assign the volume slider and all preference text fields on SO_Manager.",
                this);
            return;
        }

        volumeSlider.minValue = 0.01f;
        volumeSlider.maxValue = 1f;
        int savedVolume = Mathf.Clamp(PlayerPrefs.GetInt("Volume", 50), 1, 100);
        volumeSlider.SetValueWithoutNotify(savedVolume / 100f);
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        UpdateVolume(volumeSlider.value);

        playerNameText.text = "Player Name: " + PlayerPrefs.GetString("PlayerName", "Larry");
        sensitivityText.text = "Sensitivity: " + PlayerPrefs.GetFloat("Sensitivity", 1.0f).ToString();
    }

    void OnDestroy()
    {
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.RemoveListener(UpdateVolume);
        }
    }

    void UpdateVolume(float sliderValue)
    {
        int volume = Mathf.Clamp(Mathf.RoundToInt(sliderValue * 100f), 1, 100);
        volumeText.text = "Volume: " + volume;
        PlayerPrefs.SetInt("Volume", volume);
        PlayerPrefs.Save();
    }
}

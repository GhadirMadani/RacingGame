using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Import the TextMeshPro namespace

public class LoadLapTime : MonoBehaviour
{
    public int MinCount;
    public int SecCount;
    public float MilliCount;

    public TextMeshProUGUI MinDisplay;
    public TextMeshProUGUI SecDisplay;
    public TextMeshProUGUI MilliDisplay;

    void Start()
    {
        // Load saved values
        MinCount = PlayerPrefs.GetInt("MinSave");
        SecCount = PlayerPrefs.GetInt("SecSave");
        MilliCount = PlayerPrefs.GetFloat("MilliSave");

        // Format display
        MinDisplay.text = MinCount.ToString("00") + ":";
        SecDisplay.text = SecCount.ToString("00") + ".";
        MilliDisplay.text = Mathf.FloorToInt(MilliCount).ToString(); // Shows only one digit (0–9)
    }
}

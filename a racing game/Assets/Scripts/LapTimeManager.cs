using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // ← Add this

public class LapTimeManager : MonoBehaviour
{
    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;

    // Drag your TMP_Text references directly in the Inspector
    public TextMeshProUGUI MinuteBox;
    public TextMeshProUGUI SecondBox;
    public TextMeshProUGUI MilliBox;

    public static float RawTime;

    void Update()
    {
        // Update milliseconds
        MilliCount += Time.deltaTime * 10;
        RawTime += Time.deltaTime;
        string milliDisplay = MilliCount.ToString("F0");
        MilliBox.text = milliDisplay;

        // Roll over to seconds
        if (MilliCount >= 10f)
        {
            MilliCount = 0f;
            SecondCount += 1;
        }

        // Seconds display with leading zero
        if (SecondCount <= 9)
            SecondBox.text = $"0{SecondCount}.";
        else
            SecondBox.text = $"{SecondCount}.";

        // Roll over to minutes
        if (SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }

        // Minutes display with leading zero
        if (MinuteCount <= 9)
            MinuteBox.text = $"0{MinuteCount}:";
        else
            MinuteBox.text = $"{MinuteCount}:";
    }
}
